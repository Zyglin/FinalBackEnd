using System.Collections.Generic;
using System.Linq;
using WebFilms.DataAccess.DbPatterns.Interfaces;
using WebFilms.DataAccess.Entity;
using WebFilms.Services.Interface;

namespace WebFilms.Services.Service
{
    public class UserService:ServiceConstructor,IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public void CreateUser(User user)
        {
            UnitOfWork.Users.Create(user);
        }

        public User GetUser(string email)
        {
            return UnitOfWork.Users.GetAll().FirstOrDefault(x => x.Email == email);
        }
    }
}
