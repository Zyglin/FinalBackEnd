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
            var data = tokenDecode.DecodeJwt(_httpContextAccessor);
            string mail = data["Email"];
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
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
            if (oldUser != null && PBKDF2Helper.IsValidHash(model.OldPassword, oldUser.PasswordHash))
            {
                User _user = _mapper.Map<EditUserViewModel, User>(model);
                oldUser.Filebase64 = _user.Filebase64;
                oldUser.PasswordHash = PBKDF2Helper.CalculateHash(model.NewPassword);
                oldUser.FullName = _user.FullName;
                oldUser.PhoneNumber = _user.PhoneNumber;
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
