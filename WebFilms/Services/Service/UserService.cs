using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<User> CreateUser(User user)
        {
            return await UnitOfWork.Users.Create(user);
        }

        public async Task<User> GetUser(string email)
        {
            IList<User> users = await UnitOfWork.Users.GetAll();
            return users.FirstOrDefault(x => x.Email == email);
        }

        public async Task UpdateUser(User user)
        {
            await UnitOfWork.Users.Update(user);
        }
    }
}
