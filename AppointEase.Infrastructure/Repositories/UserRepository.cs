using AppointEase.Domain.Entities;
using AppointEase.Domain.Interfaces.Repositories;
using AppointEase.Infrastructure.Data;

namespace AppointEase.Infrastructure.Repositories
{
    public class UserRepository(AppointEaseDbContext context) : BaseRepository<User>(context), IUserRepository
    {
    }
}
