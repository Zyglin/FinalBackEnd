using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.DbPatterns.Interfaces;
using WebFilms.DataAccess.Entity;
using WebFilms.Services.Interface;

namespace WebFilms.Services.Service
{
    public class CommentService : ServiceConstructor, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<Comment> CreateComment(Comment comment)
        {
           return await UnitOfWork.Comments.Create(comment);
        }

        public async Task<IList<Comment>> GetComments(Guid id)
        {
            return await UnitOfWork.Comments.Filter(g => g.FilmId == id, "User");
        }
    }
}
