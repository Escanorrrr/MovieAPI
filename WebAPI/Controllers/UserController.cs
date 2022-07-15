using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IConfiguration _configuration;

        public UserController(MovieContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet("login")]
        public string Login(string Username, string Password)
        {
            var user = _context.Logins.FirstOrDefault(x => x.UserName == Username && x.Password == Password);
            if (user != null)
            {
              return GenerateToken(user.UserName);
            }
            return "";
            
        }
        private string GenerateToken(string UserName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Application:JWTSecret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "ARVATO",
                Issuer = "ARVATO.Issuer.Development",
                Subject = new ClaimsIdentity(new[]
                {
                    //Add any claim
                    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
