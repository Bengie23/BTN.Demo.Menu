using BTN.Demo.Menu.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Services.Dto.Transformers
{
    /// <summary>
    /// Transformer Helper for Drink Entity
    /// </summary>
    public static class DrinkTransformer
    {
        /// <summary>
        /// Transforms given Drink Entity into a Drink dto.
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public static DrinkDto AsExternalDrink(this Drink drink)
        {
            return new DrinkDto
            {
                Name = drink.Name,
                BrandName = drink.BrandName
            };
        }

        /// <summary>
        /// Transforms given Drinks into drink DTOs.
        /// </summary>
        /// <param name="drinks"></param>
        /// <returns></returns>
        public static IQueryable<DrinkDto> AsExternalDrinks(this IQueryable<Drink> drinks)
        {

            return drinks.Select(drink => drink.AsExternalDrink());
        }
    }
}
