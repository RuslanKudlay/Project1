using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private List<LoginModel> people = new List<LoginModel>
        {
            new LoginModel { UserName = "1", Password = "1", Role = "Manager"},
             new LoginModel { UserName = "2", Password = "2", Role = "Editor"}
        };
       [HttpPost]
       [Route("login")]
       public IActionResult Login (LoginModel user)
        {
            if(user == null) { return BadRequest("Invalid data"); }
            var identy = GetIdentity(user.UserName, user.Password);
            if(identy != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:47233/",
                    audience: "http://localhost:47233/",
                    claims: identy.Claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }

            
        }
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            LoginModel person = people.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }

    }
}
