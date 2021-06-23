using BTN.Demo.Menu.Data.DbContext;
using BTN.Demo.Menu.Data.Repositories;
using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BTN.Demo.Menu.Infra.Startup
{
    /// <summary>
    /// Extensions for configuring services
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// Registers Repositories 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddSingleton(new DrinkDbContext());
            services.AddSingleton<IDrinksRepository, DrinksRepository>();
            services.AddTransient(typeof(IRepositoryDataSeeding<Drink>), typeof(DrinksRepository));
            
            return services;
        }

        /// <summary>
        /// Register Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDrinksService, DrinksService>();
            return services;
        }


    }
}
