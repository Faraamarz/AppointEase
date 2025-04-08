using AppointEase.Domain.Interfaces.Repositories;

namespace AppointEase.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IServicesRepository ServicesRepository { get; }

        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> SaveAsync();
        int Save();
    }
}
