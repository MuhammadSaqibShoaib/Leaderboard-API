using LeaderboardAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LeaderboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly String UserName = "admin";
        private readonly String Password = "password123";
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult<String> Login(LoginDto loginDto)
        {
            if (!loginDto.UserName.Equals(UserName) || !loginDto.Password.Equals(Password))
            {
                return Unauthorized("Usernmae or Password is incorrect");
            }
            var jwtSettings = _configuration.GetSection("JwtSettings");

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, UserName));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiryMinutes"])),  // DateTime, use JwtSettings ExpiryMinutes from config
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = credentials
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);
            return Ok(handler.WriteToken(token));
        }
    }
}
