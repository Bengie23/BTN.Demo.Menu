using BTN.Demo.Menu.Data.Data;
using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Infra.Startup
{
    /// <summary>
    /// Extensions for seeding mechanism
    /// </summary>
    public static class Seeder
    {
        public static async Task<IServiceCollection> SeedDrinks(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var repo = sp.GetRequiredService<IRepositoryDataSeeding<Drink>>();
            
            await repo.Reset();
            
            var drinkDataSeed = new DrinkDataSeed(repo);

            await drinkDataSeed.Run();

            return services;
        }

        public static async Task<IServiceCollection> SeedCountries(this IServiceCollection services)
        {

            var sp = services.BuildServiceProvider();
            var repo = sp.GetRequiredService<IRepositoryDataSeeding<Country>>();

            await repo.Reset();

            var drinkDataSeed = new CountryDataSeed(repo);

            await drinkDataSeed.Run();

            return services;

        }
    }
}
