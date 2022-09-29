using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUF_2000M_API.Models;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TUF_2000M_API.Controllers
{
    public class AccountController : Controller
    {

        private IConfiguration Configuration { get; }


        public AccountController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = new Dictionary<string, string>();

            if (request.userName != "admin" || request.Password != "testpass")
            {
                response = new Dictionary<string, string>();
                response.Add("Error", " Invalid username and pass");
                return BadRequest(response);
            }

            var role = new List<String> { "role1", "role2" };

            string token = GenerateJWTToken(request.userName, role);


            return Ok(new LoginResponse() { AccesToken = token, UserName = request.userName });

        }

        private string GenerateJWTToken(string userName, List<String> roles)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userName)
                };
            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Name, role));
            });


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(Configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }

    }
}