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
            var filteredData = data.Where(item => context.CustomerAge >= item.AvailableAtAge);

            context.Data = filteredData;
        }
    }
}
