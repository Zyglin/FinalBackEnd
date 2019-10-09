using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFilms.DataAccess;
using WebFilms.DataAccess.Entity;
using WebFilms.JwtClass;
using WebFilms.Services.Interface;
using WebFilms.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFilms.Controllers
{
    [Route("api/[controller]")]
    public class EditUserController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private IUserService _userService;

        Jwt tokenDecode = new Jwt();

        public EditUserController(IMapper mapper, IHttpContextAccessor httpContextAccessor,IUserService userService)
        {         
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
            var data = tokenDecode.DecodeJwt(_httpContextAccessor);
            string mail = data["Email"];
            User user = await _userService.GetUser(mail);
            return Ok((new { user = user.Email, jwt = accessToken, fullName = user.FullName, number = user.PhoneNumber, imageBase64 = user.Filebase64 }));
        }



        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]EditUserViewModel model)
        {
            var data = tokenDecode.DecodeJwt(_httpContextAccessor);
            string mail = data["Email"];
            User oldUser = await _userService.GetUser(mail);
            if (oldUser != null)
            {          
                oldUser.FullName = model.FullName;
                oldUser.PhoneNumber = model.PhoneNumber;
                if(model.Filebase64 != null) oldUser.Filebase64 = model.Filebase64;
                if (model.OldPassword != null && model.NewPassword != null && PBKDF2Helper.IsValidHash(model.OldPassword, oldUser.PasswordHash)) oldUser.PasswordHash = PBKDF2Helper.CalculateHash(model.NewPassword);
                await _userService.UpdateUser(oldUser);
                return Ok();
            }
            else
            {
                return BadRequest("Password incorrect");
            }
        }
    }
}
