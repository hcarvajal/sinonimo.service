using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Asp.Versioning;
using Service.Abstraction;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using Models.DTOJuego;

namespace sinonimo.service.Controllers
{
    [Route("api/v{version:apiVersion}/juego")]
    [ApiController]
    [Authorize(Policy = "IsAdmin")]
    [ApiVersion("1.0")]
    [EnableCors("_sinonimoSpecificOrigins")]
    public class JuegoController : ControllerBase
    {
        private readonly ILogger<JuegoController> logger;
        private readonly IServiceManager _serviceManager;

        public JuegoController(ILogger<JuegoController> logger, IServiceManager serviceManager)
        {
            this.logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JuegoDTO>> GetJuegos(CancellationToken cancellation)
        {
            var Juegos = await _serviceManager.JuegoService.GetJuegosAsync(cancellation);

            if (Juegos == null)
            {
                logger.LogInformation("$Did not return any users. No Juego Found");
                return NotFound();
            }

            return Ok(Juegos);
        }

        [HttpGet("{juego}")]
        public async Task<ActionResult<JuegoDTO>> GetJuego(string juego, CancellationToken cancellationToken)
        {
            var juegos = await _serviceManager.JuegoService.GetByNameAsync(juego, cancellationToken);

            if (juegos == null)
            {
                logger.LogInformation($"Juego with name {juego} was not found");

                return NotFound();
            }

            return Ok(juegos);
        }

        [HttpPost]
        public async Task<ActionResult<JuegoDTO>> CreateJuego([FromBody]JuegoForCreateDTO createDTO, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool juegoExist = await _serviceManager.JuegoService.JuegoExistAsync(createDTO.Nombre, cancellationToken);

            if (!juegoExist)
            {
                var juegoDTO = await _serviceManager.JuegoService.CreatedAsync(createDTO, cancellationToken);
                return Ok(juegoDTO);
            }
            else
            {
                return BadRequest("juego ya existe");
            }

        }

        [HttpPut("{juego}")]
        public async Task<ActionResult> UpdateJuego(string juego, JuegoForUpdateDTO updateDTO, CancellationToken cancellationToken)
        {
          if(!await _serviceManager.JuegoService.JuegoExistAsync(juego, cancellationToken))
            {
                return NotFound();
            }

          var juegoDTO = await _serviceManager.JuegoService.UpdateAsync(juego,updateDTO, cancellationToken);

            return NoContent();
        
        }
    }
}
