using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Asp.Versioning;
using Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Models.DTOSubJuego;

namespace sinonimo.service.Controllers
{
    [Route("api/v{version:apiVersion}/subjuego")]
    [ApiController]
    [Authorize(Policy = "IsAdmin")]
    [ApiVersion("1.0")]
    [EnableCors("_sinonimoSpecificOrigins")]
    public class SubJuegoController : ControllerBase
    {
        private readonly ILogger<SubJuegoController> logger;
        private readonly IServiceManager _serviceManager;

        public SubJuegoController(ILogger<SubJuegoController> logger, IServiceManager serviceManager)
        {
            this.logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SubJuegoDTO>> GetJuegos(CancellationToken cancellation)
        {
            var Juegos = await _serviceManager.SubJuegoService.GetJuegosAsync(cancellation);

            if(Juegos == null)
            {
                logger.LogInformation("Did not return any sub juego. No Juego Found");
                return NotFound();
            }

            return Ok(Juegos);
        }


        [HttpGet("{subjuego}")]
        public async Task<ActionResult<SubJuegoDTO>> GetJuego(string subJuego, CancellationToken cancellationToken)
        {
            var juego = await _serviceManager.SubJuegoService.GetByNameAsync(subJuego,cancellationToken);

            if(juego == null)
            {
                logger.LogInformation($"Sub Jeugo with name {subJuego} was not found");

                return NotFound(); 
            }

            return Ok(juego);
        }

        [HttpPost]
        public async Task<ActionResult<SubJuegoDTO>> CreateSubJuego(SubJuegoForCreateDTO subJuego, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            bool subJuegoExist = await _serviceManager.SubJuegoService.SubJuegoExistAsync(subJuego.Name, cancellationToken); 

            if(!subJuegoExist)
            {
                var subJuegoDTO = await _serviceManager.SubJuegoService.CreatedAsync(subJuego,cancellationToken).ConfigureAwait(false);
                return Ok(subJuegoDTO);
            }else
            {
                return BadRequest("sub juego ya existe");
            }

        }

        [HttpPut("{subjuego}")]
        public async Task<ActionResult> UpdateJuego(string juego, SubJuegoForUpdateDTO updateDTO,CancellationToken cancellation)
        {
            if (!await _serviceManager.SubJuegoService.SubJuegoExistAsync(juego, cancellation).ConfigureAwait(false))
            {
                return NotFound();
            }

            var subJuegoDTO = await _serviceManager.SubJuegoService.UpdateAsync(juego,updateDTO,cancellation).ConfigureAwait(false);

            return NoContent();
        }





    }
}
