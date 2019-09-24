using DataAccess.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebFilms.Services.Interface
{
    public interface IRatingService
    {
        Task<Rating> CreateRating(Rating rating);
        Task<Rating> GetRating(Guid filmId, Guid userId);
        Task<IList<Rating>> GetRatings(Guid id);


    }
}
