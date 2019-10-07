using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebFilms.DataAccess;
using WebFilms.DataAccess.Entity;
using WebFilms.Services.Interface;
using WebFilms.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFilms.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private IUserService _userService;
        private readonly IMapper _mapper;


        public RegistrationController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                User userValid = await _userService.GetUser(model.Email);
                if (userValid == null && model.Password == model.ConfirmPassword)
                {
                    User user = _mapper.Map<RegistrationViewModel, User>(model);
                    user.Id = Guid.NewGuid();
                    user.PasswordHash = PBKDF2Helper.CalculateHash(model.ConfirmPassword);
                    await _userService.CreateUser(user);
                    return Ok();
                }
                else
                {
                    return BadRequest("User is already registered");
                }
            }           
            else
            {
                return BadRequest();
            }
        }
    }
}
