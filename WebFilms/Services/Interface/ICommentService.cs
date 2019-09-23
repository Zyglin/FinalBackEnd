using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilms.DataAccess.Entity;

namespace WebFilms.Services.Interface
{
    public interface ICommentService
    {
        void CreateComment(Comment comment);
        IEnumerable<Comment> GetComments(Guid id);

    }
}
