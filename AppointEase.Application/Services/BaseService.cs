using AppointEase.Application.Interfaces;
using AppointEase.Domain.Interfaces.UnitOfWork;

namespace AppointEase.Application.Services
{
    public class BaseService<T>(IUnitOfWork unitOfWork) : IBaseService<T> where T : class
    {
        public virtual async Task<bool> Add(T entity)
        {
            await unitOfWork.GetRepository<T>().AddAsync(entity);
            await unitOfWork.SaveAsync();
            return true;
        }

        public virtual async Task<bool> Delete(object id)
        {
            await unitOfWork.GetRepository<T>().Delete(id);
            await unitOfWork.SaveAsync();
            return true;
        }

        public virtual async Task<T?> Find(object id)
        {
            return await unitOfWork.GetRepository<T>().GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<object>> GetAll()
        {
            return await unitOfWork.GetRepository<T>().GetAll();
        }

        public virtual async Task<object?> GetById(object id)
        {
            return await unitOfWork.GetRepository<T>().GetByIdAsync(id);
        }

        public virtual async Task<bool> Update(T entity)
        {
            await unitOfWork.GetRepository<T>().Update(entity);
            await unitOfWork.SaveAsync();
            return true;
        }
    }
}
