using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFilms.DataAccess.DbPatterns.Interfaces;
using WebFilms.DataAccess.Entity;
using WebFilms.Services.Interface;

namespace WebFilms.Services.Service
{
    public class FilmService:ServiceConstructor,IFilmService
    {
        public FilmService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<IList<Film>> GetAllFilms()
        {
            return await UnitOfWork.Films.GetAll();
        }

        public async Task<Film> GetFilm(Guid id)
        {
            return await UnitOfWork.Films.Get(id);
        }
    }
}
