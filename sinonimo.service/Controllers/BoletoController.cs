using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Asp.Versioning;
using Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Models.DTOBoleto;

namespace sinonimo.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
    }
}
