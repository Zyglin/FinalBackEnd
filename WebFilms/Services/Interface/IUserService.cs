using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.Services.Interface
{
    public interface IUserService
    {
        Task<User> GetUser(string email);
        Task<User> CreateUser(User user);
    }
}
