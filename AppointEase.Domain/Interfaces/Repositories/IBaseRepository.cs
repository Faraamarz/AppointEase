using System.Linq.Expressions;

namespace AppointEase.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object?>>[]? includes);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> DeleteRange(IEnumerable<T> entities);
        Task<bool> Delete(object id);
    }
}
