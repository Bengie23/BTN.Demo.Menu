using BTN.Demo.Menu.Domain.Entities;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    public class CountryEvaluator : BaseEvaluator, IEvaluator
    {
        public CountryEvaluator()
        {

        }

        public static string CountryKey = "CountryKey";
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
