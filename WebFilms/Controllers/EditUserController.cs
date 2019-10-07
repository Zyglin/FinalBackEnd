using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFilms.JwtClass;
using WebFilms.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFilms.Controllers
{
    [Route("api/[controller]")]
    public class EditUserController : Controller
    {
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        Jwt tokenDecode = new Jwt();

        public EditUserController(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {         
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]EditUserViewModel model)
        {
            var httpRequest = HttpContext.Request;
            var data = tokenDecode.DecodeJwt(_httpContextAccessor);
            Guid userId = Guid.Parse(data["idUser"]);
            //Comment _comment = _mapper.Map<CommentViewModel, Comment>(model);
            //_comment.Id = Guid.NewGuid();
            //_comment.UserId = userId;
            //await _commentService.CreateComment(_comment);
            return Ok();
        }
    }
}
