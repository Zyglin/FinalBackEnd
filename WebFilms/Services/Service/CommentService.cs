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
        public void CreateComment(Comment comment)
        {
            UnitOfWork.Comments.Create(comment);
        }

        public IEnumerable<Comment> GetComments(Guid id)
        {
            return UnitOfWork.Comments.Filter(g => g.FilmId == id, "User");
        }
    }
}
