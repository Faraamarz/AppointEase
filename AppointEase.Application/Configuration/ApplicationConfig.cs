using AppointEase.Application.Interfaces;
using AppointEase.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppointEase.Application.Configuration
{
    public static class ApplicationConfig
    {
        public static void Config(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IServicesService, ServicesService>();
        }
    }
}
