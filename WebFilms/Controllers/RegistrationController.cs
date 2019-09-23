using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public RegistrationController(IUserService userService)
        {

            _userService = userService;
        }

        // POST api/<controller>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                User userValid = await _userService.GetUser(model.Email);

                if (userValid == null && model.Password == model.ConfirmPassword)
                {
                    User user = new User()
                    {
                        Id = Guid.NewGuid(),
                        Email = model.Email,
                        PasswordHash = PBKDF2Helper.CalculateHash(model.ConfirmPassword),
                    };
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
