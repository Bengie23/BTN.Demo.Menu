using System;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    public class StockEvaluator : IEvaluator
    {
        ///<inheritdoc cref="IEvaluator.Evaluate(DrinkMenuContext)"/>
        public void Evaluate(DrinkMenuContext context)
        {
            if (context.EvaluateStock)
            {
                var data = context.Data;
                context.Data = data.Where(drink => drink.InStock);
            }
        }
    }
}
