using Microsoft.Extensions.DependencyInjection;

namespace BTN.Demo.Menu.Services
{
    public static class DIBootstrap
    {
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
