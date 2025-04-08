using AppointEase.Domain.Interfaces.Repositories;
using AppointEase.Domain.Interfaces.UnitOfWork;
using AppointEase.Infrastructure.Data;
using AppointEase.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointEase.Infrastructure.Configuration
{
    public static class InfrastructureConfig
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default") ?? string.Empty;
            services.AddDbContext<AppointEaseDbContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IServicesRepository, ServicesRepository>();
        }
    }
}
