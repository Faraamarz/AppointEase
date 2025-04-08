using AppointEase.Domain.Interfaces.Repositories;
using AppointEase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppointEase.Infrastructure.Repositories
{
    public class BaseRepository<T>(AppointEaseDbContext context) : IBaseRepository<T> where T : class
    {
        public virtual async Task<bool> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            return true;
        }

        public virtual Task<bool> Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return Task.FromResult(true);
        }

        public virtual async Task<bool> Delete(object id)
        {
            var entity = await GetByIdAsync((int)id);
            return await Delete(entity!);
        }

        public async Task<bool> DeleteRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object?>>[]? includes)
        {
            IQueryable<T> query = context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.Where(filter).ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(true);
        }
    }
}
