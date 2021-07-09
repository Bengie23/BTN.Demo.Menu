using BTN.Demo.Menu.Domain.Entities;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    /// <summary>
    /// Evaluates what drink menu should be displayed based on customer's age.
    /// </summary>
    public class AgeEvaluator : BaseEvaluator, IEvaluator
    {
        public static string CustomerAgeKey = "CustomerAge";

        ///<inheritdoc cref="IEvaluator.Evaluate(DrinkMenuContext)"/>
        public void Evaluate(DrinkMenuContext context)
        {
            IQueryable<Drink> data = context.Data;

            int customerAge = GetProperty<int>(context, CustomerAgeKey);

            var filteredData = FilterByAge(data, customerAge);

            context.Data = filteredData;
        }   

        private IQueryable<Drink> FilterByAge(IQueryable<Drink> data, int customerAge)
        {
            return data.Where(item => item is IAgeAvailability && customerAge >= item.AvailableAtAge);
        }
    }
}
