using APIAmbiental.Models;
using APIAmbiental.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIAmbiental.Controllers
{
    [ApiVersion(1, Deprecated = true)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IAuthService _authService2;
        public AuthController()
        {
            _authService = new AuthService(); // Em um cenário real, isso deve ser injetado via DI
        }


        

        public AuthController(IAuthService authService)
        {
            _authService2 = authService; // Injeção de dependência via construtor
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            var authenticatedUser = _authService.Authenticate(user.Username, user.Password);
            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(authenticatedUser);
            return Ok(new { Token = token });
        }


        private string GenerateJwtToken(UserModel user)
        {

            byte[] secret = Encoding.ASCII.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi");
            var securityKey = new SymmetricSecurityKey(secret);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Hash, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = "fiap",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
