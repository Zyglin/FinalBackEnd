using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.DataAccess.Entity;
using WebFilms.DataAccess.DbPatterns.Interfaces;
using WebFilms.Services.Interface;

namespace WebFilms.Services.Service
{
    public class RatingService:ServiceConstructor,IRatingService
    {
        public RatingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<Rating> CreateRating(Rating rating)
        {
            return await UnitOfWork.Ratings.Create(rating);
        }

        public async Task<IList<Rating>> GetRatings(Guid id)
        {
            IList<Rating> ts = await UnitOfWork.Ratings.GetAll();
            return ts.Where(x => x.FilmId == id).ToList();
        }

        public async Task<Rating> GetRating(Guid filmId, Guid userId)
        {
            IList<Rating> ts = await UnitOfWork.Ratings.GetAll();
            return ts.FirstOrDefault(x => x.FilmId == filmId && x.UserId == userId);
        }
    }
}
