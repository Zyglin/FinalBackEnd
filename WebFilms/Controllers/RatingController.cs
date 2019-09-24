using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.DataAccess.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebFilms.JwtClass;
using WebFilms.Services.Interface;
using WebFilms.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFilms.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : Controller
    {
        private IRatingService _ratingService;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        Jwt tokenDecode = new Jwt();
        public RatingController(IRatingService ratingService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _ratingService = ratingService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            IList <Rating> allRaitings = await _ratingService.GetRatings(id);
            int stars = 0;
            if (allRaitings.Count != 0)
            {
                foreach (var item in allRaitings)
                {
                    stars += item.Value;
                }
                stars = stars / allRaitings.Count;
                return Ok(stars);
            }
            return Ok(stars);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]RatingViewModel model)
        {
            var data = tokenDecode.DecodeJwt(_httpContextAccessor);
            Guid UserId = Guid.Parse(data["idUser"]);
            Rating _rating = await _ratingService.GetRating(model.FilmId, UserId);
            if (_rating == null)
            {
                Rating rating = _mapper.Map<RatingViewModel, Rating>(model);
                rating.Id = Guid.NewGuid();
                rating.UserId = UserId;

                //Rating rating = new Rating()
                //{
                //    Id = Guid.NewGuid(),
                //    FilmId = FilmId,
                //    UserId = UserId,
                //    Value = model.Value
                //};

                await _ratingService.CreateRating(rating);

                return Ok();
            }
            return Ok("User voted");
        }

    }
}
