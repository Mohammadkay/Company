using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> RemoveAsync(T entity);
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> RemoveRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> GetAsync(long id);
        IQueryable<T> Find(Expression<Func<T, bool>> filter, string? includes = null);
        IQueryable<T> Filter(Expression<Func<T, bool>> where, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task SaveChangesAsync();

    }
}
