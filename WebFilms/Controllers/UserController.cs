using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebFilms.DataAccess;
using WebFilms.DataAccess.Entity;
using WebFilms.Services.Interface;
using WebFilms.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFilms.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private IConfiguration _config;
        private IUserService _userService;
     
        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }


        //[HttpGet]
        //[Authorize]
        //public IActionResult Get()
        //{
        //    var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
        //    var handler = new JwtSecurityTokenHandler();
        //    var tokenS = handler.ReadJwtToken(accessToken) as JwtSecurityToken;
        //    var id = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId).Value;
        //    var email = tokenS.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;

        //    return Ok(new { UserEmail= email,UserId = id});
        //}

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IActionResult response = Unauthorized();

                User user = await _userService.GetUser(model.Email);

                if (user != null && PBKDF2Helper.IsValidHash(model.Password, user.PasswordHash))
                {
                    var tokenString = GenerateJSONWebToken(user);
                    response = Ok(new { user=user.Email ,jwt = tokenString });
                }
                return response;
            }
            else
            {
                return BadRequest();
            }
          
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                    new Claim(JwtRegisteredClaimNames.NameId, userInfo.Id.ToString()),
                };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
