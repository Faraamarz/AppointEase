using AppointEase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointEase.Infrastructure.Data
{
    public class AppointEaseDbContext(DbContextOptions<AppointEaseDbContext> options) : DbContext(options)
    {
        public required DbSet<User> Users { get; set; }
        public required DbSet<Customer> Customers { get; set; }
        public required DbSet<Services> Services { get; set; }
    }
}
