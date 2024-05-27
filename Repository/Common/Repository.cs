using Microsoft.EntityFrameworkCore;
using Migrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public class Repository<T> : IRepository<T> where T : class
    {
         private readonly ZzV10Context _context;

        public Repository(ZzV10Context context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> filter, string? includes = null)
        {
            IQueryable<T> dbquery = _context.Set<T>().AsNoTracking().Where(filter);
            if (includes != null)
            {
                foreach (var item in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    dbquery = q.Include(item);
                }
            }
            return dbquery.AsNoTracking();
        }

        public IQueryable<T> GetAll()
        {
           return _context.Set<T>().AsNoTracking();
        }

        public void SaveChanges()
        {
          _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public T  Get(int id) {
            return _context.Set<T>().AsNoTracking.Where(entity=>entity.Id==id).FirstOrDefault();
        }
    }
}
