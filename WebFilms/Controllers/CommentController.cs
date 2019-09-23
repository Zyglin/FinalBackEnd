using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFilms.DataAccess.Entity;
using WebFilms.JwtClass;
using WebFilms.Services.Interface;
using WebFilms.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFilms.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private ICommentService _commentService;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        Jwt tokenDecode = new Jwt();

        public CommentController(ICommentService commentService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _commentService = commentService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        // GET: api/<controller>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var model = new ListCommentsViewModel();
            List<Comment> comments = _commentService.GetComments(id).ToList();
            model.Comments = _mapper.Map<List<Comment>, List<CommentViewModel>>(comments);
            return Ok(model.Comments);  
        }

        [HttpPost]
        public IActionResult Post([FromBody]CommentViewModel model)
        {
            var data = tokenDecode.DecodeJwt(_httpContextAccessor);
            string UserId = data["idUser"];
            Comment comment = new Comment
            {
                Id= Guid.NewGuid(),
                Description = model.Description,
                FilmId = Guid.Parse(model.FilmId),
                UserId = Guid.Parse(UserId)
            };

            _commentService.CreateComment(comment);


            return Ok();
        }
    }
}
