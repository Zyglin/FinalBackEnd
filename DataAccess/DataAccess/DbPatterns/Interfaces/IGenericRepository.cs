using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebFilms.DataAccess.DbPatterns.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> Create(T t);
        Task Delete(T t);
        Task Update(T t);
        Task<T> Get(Guid id);
        Task<IList<T>> GetAll();
        //void Update(T t);
        Task<IList<T>> Filter(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        //IEnumerable<T> FilterTwo(params string[] navigationProperties);
    }
}
