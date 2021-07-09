using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
using Microsoft.Extensions.DependencyInjection;

namespace BTN.Demo.Menu.Domain.Requests
{
    /// <summary>
    /// Helper class for DI registration
    /// </summary>
    public static class DIBootstrap
    {
        /// <summary>
        /// Register evaluators
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterEvaluators(this IServiceCollection services)
        {
            services.AddSingleton<IEvaluator, AgeEvaluator>();
            services.AddSingleton<IEvaluator, StockEvaluator>();
            services.AddSingleton<IEvaluator, CountryEvaluator>();

            return services;
        }
    }
}
