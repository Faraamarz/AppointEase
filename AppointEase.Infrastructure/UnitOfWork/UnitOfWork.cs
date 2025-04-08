using AppointEase.Domain.Interfaces.Repositories;
using AppointEase.Domain.Interfaces.UnitOfWork;
using AppointEase.Infrastructure.Data;
using AppointEase.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppointEase.Infrastructure.UnitOfWork
{
    public class UnitOfWork(AppointEaseDbContext context) : IUnitOfWork
    {
        private readonly AppointEaseDbContext _context = context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private IDbContextTransaction? _transaction;


        private UserRepository? _userRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        private CustomerRepository? _customerRepository;
        public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

        private ServicesRepository? _servicesRepository;
        public IServicesRepository ServicesRepository => _servicesRepository ??= new ServicesRepository(_context);

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            if (!_repositories.TryGetValue(type, out var value))
            {
                var repositoryInstance = new BaseRepository<TEntity>(_context);
                value = repositoryInstance;
                _repositories.Add(type, value);
            }

            return (IBaseRepository<TEntity>)value;
        }
    }
}
