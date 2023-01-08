using Business.Abstract;
using Business.Concrete;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddDataAccessServices();
            services.AddScoped<IProductManager, ProductManager>();

            return services;
        }
    }
}
