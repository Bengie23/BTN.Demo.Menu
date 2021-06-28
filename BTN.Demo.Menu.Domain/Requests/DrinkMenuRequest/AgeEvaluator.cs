using BTN.Demo.Menu.Domain.Entities;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    /// <summary>
    /// Evaluates what drink menu should be displayed based on customer's age.
    /// </summary>
    public class AgeEvaluator : IEvaluator
    {
        ///<inheritdoc cref="IEvaluator.Evaluate(DrinkMenuContext)"/>
        public void Evaluate(DrinkMenuContext context)
        {
            var data = context.Data;
            var filteredData = FilterByAge(data, context.CustomerAge);

            context.Data = filteredData;
        }   

        private IQueryable<Drink> FilterByAge(IQueryable<Drink> data, int customerAge)
        {
            return data.Where(item => item is IAgeAvailability && customerAge >= item.AvailableAtAge);
        }
    }
}
