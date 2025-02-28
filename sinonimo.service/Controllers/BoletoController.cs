using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Asp.Versioning;
using Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Models.DTOBoleto;
using ZstdSharp.Unsafe;

namespace sinonimo.service.Controllers
{
    [Route("api/v{version:apiVersion}/boleto")]
    [ApiController]
    [Authorize(Policy = "IsAdmin")]
    [ApiVersion("1.0")]
    [EnableCors("_sinonimoSpecificOrigins")]
    public class BoletoController : ControllerBase
    {
        private readonly ILogger<BoletoController> logger;
        private readonly IServiceManager _serviceManager;

        public BoletoController(ILogger<BoletoController> logger, IServiceManager serviceManager)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceManager = serviceManager ?? throw new ArgumentNullException(nameof(serviceManager));

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BoletoDTO>> GetBoletos(CancellationToken cancellationToken)
        {
            var boletos = await _serviceManager.BoletoService.BoletoListAsync(cancellationToken);

            if (boletos == null)
            {
                logger.LogInformation("$Did not return any boleto. No Boleto Found");
                return NotFound();
            }

            return Ok(boletos);
        }

        [HttpGet("{boleto}")]
        public async Task<ActionResult<BoletoDTO>> GetBoleto(string boleto, CancellationToken cancellation)
        {
            var boletos = await _serviceManager.BoletoService.GetByNameAsync(boleto, cancellation);

            if (boletos == null)
            {
                logger.LogInformation($"{boleto} no encontrado");
                return NotFound();
            }

            return Ok(boletos);
        }

        [HttpPost]
        public async Task<ActionResult<BoletoDTO>> CreateBoleto([FromBody] BoletoForCreateDTO createDTO, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            bool BoletoExist = await _serviceManager.BoletoService.BoletoExistAsync(createDTO.BoletoId, cancellationToken);

            if (!BoletoExist)
            {
                var boletoDTO = await _serviceManager.BoletoService.CreateAsync(createDTO, cancellationToken);
                return Ok(boletoDTO);
            } else
            {
                return BadRequest("boleto ya existe");
            }
        }


        /// <summary>
        /// Actualizar el boleto ya que se puede actualizar. La transaccion no cambia.
        /// </summary>
        /// <param name="boletoId"></param>
        /// <param name="udpdateDTO"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateBoleto(string boletoId, BoletoForUpdateDTO udpdateDTO, CancellationToken cancellationToken)
        {
            if(!await _serviceManager.BoletoService.BoletoExistAsync(boletoId, cancellationToken))
            {
                return NotFound();
            }

            var boleto = await _serviceManager.BoletoService.UpdateAsync(boletoId, udpdateDTO, cancellationToken);

            return NoContent();
        }


    }
}
