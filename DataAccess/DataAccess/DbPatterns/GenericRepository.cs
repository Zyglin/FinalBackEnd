using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebFilms.DataAccess.DbPatterns.Interfaces;

namespace WebFilms.DataAccess.DbPatterns
{

    public class GenericRepository<T> :
  IGenericRepository<T> where T : class
    {
        private readonly MyDbContext _context;

        public GenericRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T t)
        {
            _context.Set<T>().Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        public async Task<int> Delete(T t)
        { 
           _context.Set<T>().Remove(t);
           return await _context.SaveChangesAsync(); 
        }

        public async Task<T> Get(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public void Update(T t)
        {
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<IList<T>> Filter(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty);
            }
            var list = await query.Where(predicate).ToListAsync();
            return list;
        }

        //public IEnumerable<T> FilterTwo(params string[] navigationProperties)
        //{
        //    var query = _context.Set<T>().AsQueryable();
        //    foreach (var navigationProperty in navigationProperties)
        //    {
        //        query = query.Include(navigationProperty);
        //    }
        //    var list = query.ToList();
        //    return list;
        //}
    }
}
