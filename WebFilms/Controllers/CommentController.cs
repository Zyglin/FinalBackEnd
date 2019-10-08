using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFilms.DataAccess.Entity;
using WebFilms.JwtClass;
using WebFilms.Services.Interface;
using WebFilms.ViewModel;


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

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            var model = new ListCommentsViewModel();
            IList<Comment> comments = await _commentService.GetComments(id);
            model.Comments = _mapper.Map<IList<Comment>, List<CommentViewModel>>(comments);
            
            return Ok(model.Comments);  
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]CommentViewModel model)
        {
            var data = tokenDecode.DecodeJwt(_httpContextAccessor);
            Guid userId = Guid.Parse(data["idUser"]);
            Comment _comment = _mapper.Map<CommentViewModel, Comment>(model);
            _comment.Id = Guid.NewGuid();
            _comment.UserId = userId;
            await _commentService.CreateComment(_comment);
            return Ok(_comment.FilmId);
        }
    }
}
