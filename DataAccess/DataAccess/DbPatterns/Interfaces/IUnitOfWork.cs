using DataAccess.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.DataAccess.DbPatterns.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Film> Films { get; }
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Comment> Comments { get; }
        IGenericRepository<Rating> Ratings { get; }
        void Save();
    }
}
