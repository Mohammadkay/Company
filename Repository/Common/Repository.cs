using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Migrations.Models;

namespace Repository.Common
{
    public class Repository<T> : IRepository<T> where T : BaseModel,new()
    {
         private readonly ZzV10Context _context;

        public Repository(ZzV10Context context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreationDate = DateTime.Now;
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreationDate = DateTime.Now;
            }
            await _context.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
            return entities;
        }

        public async Task<T> RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> RemoveRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await SaveChangesAsync();
            return entities;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> filter, string? includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking().Where(filter);
            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
            }
            return query;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception
                throw new Exception("An error occurred while updating the database.", ex);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetAsync(long id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (include != null)
            {
                query = include(query);
            }
            return query.Where(predicate);
        }
    }
}