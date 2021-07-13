using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    /// <summary>
    /// Evaluates whether or not a country allows alcoholic drinks
    /// </summary>
    public class CountryEvaluator : BaseEvaluator, IEvaluator
    {
        public static string CountryKey = "CountryKey";

        /// <inheritdoc cref="IEvaluator.Evaluate(DrinkMenuContext)"/>
        public void Evaluate(DrinkMenuContext context)
        {
            IQueryable<Drink> data = context.Data;

            Country country = GetProperty<Country>(context, CountryKey);

            if (!country.AllowsAlcoholicDrinks)
            {
                context.Data = data.Where(drink => !drink.IsAlcoholicDrink);
            }
        }
    }
}
