using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Data.Data
{
    /// <summary>
    /// Seeds data into a persistance layer for Country Entity
    /// </summary>
    public class CountryDataSeed
    {
        private readonly IRepositoryDataSeeding<Country> repositoryDataSeeding;

        public CountryDataSeed(IRepositoryDataSeeding<Country> repositoryDataSeeding)
        {
            repositoryDataSeeding.ValidateNotNull(nameof(repositoryDataSeeding));

            this.repositoryDataSeeding = repositoryDataSeeding;
        }

        /// <summary>
        /// Performs the action of seeding data
        /// </summary>
        /// <returns></returns>
        public async Task Run()
        {
            List<Country> countries = new List<Country>();
            countries.Add(new Country() { Name = "Mexico",AllowsAlcoholicDrinks = true, Code = "MX"});
            countries.Add(new Country() { Name = "Israel", AllowsAlcoholicDrinks = false, Code = "ISR" });

            await repositoryDataSeeding.Seed(countries);
        }
    }
}
