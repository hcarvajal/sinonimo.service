using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstraction;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Models.Authentication;
using System.ComponentModel.Design.Serialization;
using Models.UserDTO;


namespace sinonimo.service.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    [EnableCors("_sinonimoSpecificOrigins")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IServiceManager serviceManager,
            IConfiguration configuration)
        {
            _serviceManager = serviceManager;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public async Task <ActionResult<string>> Authenticate(AuthenticationBody authenticationRequestBody,CancellationToken cancellationToken)
        {
            var user = await _serviceManager.UserService.ValidateUserCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password, cancellationToken);


            if(user.UserName == "")
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserName.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name",user.LastName));
            claimsForToken.Add(new Claim("email", user.Email));
            claimsForToken.Add(new Claim(ClaimTypes.Role, user.Role));

            var jwtSecurityToken  = new JwtSecurityToken(
                    _configuration["Authentication:Issuer"],
                    _configuration["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signingCredentials );

            var tokenTOReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenTOReturn);





           
        }


      

    }
}
