using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Asp.Versioning;
using Models.UserDTO;
using Service.Abstraction;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;


namespace sinonimo.service.Controllers
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [Authorize(Policy = "IsAdmin")]
    [ApiVersion("1.0")]
    [EnableCors("_sinonimoSpecificOrigins")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _Logger;
        private readonly IServiceManager _serviceManager;



        public UserController(ILogger<UserController> logger, IServiceManager serviceManager)
        {
            _Logger = logger;
            _serviceManager = serviceManager;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> GetUsers(CancellationToken cancellationToken)
        {
            var Users = await _serviceManager.UserService.GetUsersAsync(cancellationToken);

            if (Users == null)
            {
                _Logger.LogInformation("$DId not return any users. No Users Found");
                return NotFound();

            }

            return Ok(Users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserDTO>> GetUser(string username, CancellationToken cancellationToken)
        {
            var user = await _serviceManager.UserService.GeByIdAsync(username, cancellationToken);

            if (user == null)
            {
                _Logger.LogInformation($"User with usernam: {username} was not found.");
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserForCreateDTO createDTO, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool userExist = await _serviceManager.UserService.UserExist(createDTO.UserName, cancellationToken);

            if (!userExist)
            {
                var userDTO = await _serviceManager.UserService.CreateAsync(createDTO, cancellationToken);
                return Ok(userDTO);
            }
            else
            {
                return BadRequest("user already exist");
            }

        }

        [HttpPut("{username}")]
        public async Task<ActionResult> UpdateUser(string username, UserForUpdateDTO updateDTO, CancellationToken cancellationToken)
        {



            if (!await _serviceManager.UserService.UserExist(username, cancellationToken))
            {
                return NotFound();
            }

            var userDTO = await _serviceManager.UserService.UpdateAsync(username, updateDTO, cancellationToken);

            return NoContent();


        }


        [HttpPatch("{username}")]
        public async Task<ActionResult> PartialyUpdateUser(string username,JsonPatchDocument<UserForUpdateDTO> patchDocument, CancellationToken cancellationToken)
        {
            if(!await _serviceManager.UserService.UserExist(username,cancellationToken))
            {
                return NotFound();
            }
           
            var user  =  await _serviceManager.UserService.PartialyUpdateAsync(username, cancellationToken);

            patchDocument.ApplyTo(user, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(user))
            {
                return BadRequest(ModelState);
            }


            var savedUser = await _serviceManager.UserService.PartialyUpdateSaveAsync(username, user, cancellationToken);

           
            
            return NoContent();
        }

      
    }
}
