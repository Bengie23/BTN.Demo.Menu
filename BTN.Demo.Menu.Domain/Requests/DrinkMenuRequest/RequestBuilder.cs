using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    /// <summary>
    /// Builder for Drink Menu Requests
    /// </summary>
    public static class RequestBuilder
    {

        /// <summary>
        /// Executes all Evaluators for given Drink Menu Context
        /// </summary>
        /// <param name="drinkMenuContext"></param>
        /// <returns></returns>
        public static DrinkMenuContext Evaluate(this DrinkMenuContext drinkMenuContext)
        {
            foreach (var item in drinkMenuContext.Evaluators)
            {
                item.Evaluate(drinkMenuContext);
            }

            return drinkMenuContext;
        }


    }
}
