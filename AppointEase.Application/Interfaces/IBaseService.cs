using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointEase.Application.Interfaces
{
    public interface IBaseService<T>
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(object id);
        Task<IEnumerable<object>> GetAll();
        Task<object?> GetById(object id);
        Task<T?> Find(object id);
    }
}
