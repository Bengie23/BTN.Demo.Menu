using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    public class StockEvaluator : IEvaluator
    {

        ///<inheritdoc cref="IEvaluator.Evaluate(DrinkMenuContext)"/>
        public void Evaluate(DrinkMenuContext context)
        {
            context.Data = context.Data.Where(drink => drink.InStock);            
        }
    }
}
