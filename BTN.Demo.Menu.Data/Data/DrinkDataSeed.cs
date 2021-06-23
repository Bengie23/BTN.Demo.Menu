using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Data.Data
{
    /// <summary>
    /// Seeds data into a persistance layer for Drink Entity
    /// </summary>
    public class DrinkDataSeed
    {
        private readonly IRepositoryDataSeeding<Drink> repositoryDataSeeding;

        public DrinkDataSeed(IRepositoryDataSeeding<Drink> repositoryDataSeeding)
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
            var softDrinks = await GetSoftDrinks();
            var lightAlcoholicDrinks = await GetLightAlcoholicDrinks();
            var otherDrinks = await GetOtherDrinks();

            var drinks = softDrinks.Concat(lightAlcoholicDrinks).Concat(otherDrinks);
            await repositoryDataSeeding.Seed(drinks);
        }

        private async Task<IEnumerable<Drink>> GetSoftDrinks()
        {
            List<Drink> drinks = new List<Drink>();
            string brandName = "The Green & Brown Company";

            drinks.Add(new Drink() { BrandName = brandName, Name = "Bottled Water", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Orange Juice", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Sweet Tea", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Ginge Ale", AvailableAtAge = 0 });

            brandName = "The Repsi Company";
            drinks.Add(new Drink() { BrandName = brandName, Name = "Bottled Water", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Orange Juice", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Sweet Tea", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Ginge Ale", AvailableAtAge = 0 });

            brandName = "The Loca Roca Company";
            drinks.Add(new Drink() { BrandName = brandName, Name = "Bottled Water", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Orange Juice", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Sweet Tea", AvailableAtAge = 0 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Ginge Ale", AvailableAtAge = 0 });

            return drinks;
        }

        private async Task<IEnumerable<Drink>> GetLightAlcoholicDrinks()
        {
            List<Drink> drinks = new List<Drink>();
            string brandName = "Cigar City";

            drinks.Add(new Drink() { BrandName = brandName, Name = "Maduro Beer", AvailableAtAge = 18 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Guayabera Beer", AvailableAtAge = 18 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Lager Beer", AvailableAtAge = 18 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Cuba Espresso Beer", AvailableAtAge = 18 });

            brandName = "The Crown Group";

            drinks.Add(new Drink() { BrandName = brandName, Name = "Corona Beer", AvailableAtAge = 18 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Coronita Beer", AvailableAtAge = 18 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Corona Brown Beer", AvailableAtAge = 18 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Corona light Beer", AvailableAtAge = 18 });


            return drinks;
        }

        private async Task<IEnumerable<Drink>> GetOtherDrinks()
        {
            List<Drink> drinks = new List<Drink>();
            string brandName = "The Strong Stuff Company";

            drinks.Add(new Drink() { BrandName = brandName, Name = "Tequila", AvailableAtAge = 21 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Whisky", AvailableAtAge = 21 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Vodka", AvailableAtAge = 21 });
            drinks.Add(new Drink() { BrandName = brandName, Name = "Mezcal", AvailableAtAge = 21 });

            return drinks;
        }
    }
}
