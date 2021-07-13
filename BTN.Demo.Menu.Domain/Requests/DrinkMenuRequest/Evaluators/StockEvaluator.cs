using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    /// <summary>
    /// Evaluates if a drink is in-stock 
    /// </summary>
    public class StockEvaluator : IEvaluator
    {

        ///<inheritdoc cref="IEvaluator.Evaluate(DrinkMenuContext)"/>
        public void Evaluate(DrinkMenuContext context)
        {
            context.Data = context.Data.Where(drink => drink.InStock);            
        }
    }
}
