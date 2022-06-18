using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Data.Entities;

namespace WebApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthenticationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Postlogin([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (login.UserName != "" || login.Password != "")
                return Unauthorized();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("UnKhownKey"));
            var singinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.Aes128CbcHmacSha256);
            var tokenOption = new JwtSecurityToken(
                    issuer : "",
                    claims : new List<Claim>()
                    { 
                        new Claim(ClaimTypes.NameIdentifier, login.UserName)
                    },
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: singinCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
            return Ok(new { token = tokenString });
        }
    }
}
