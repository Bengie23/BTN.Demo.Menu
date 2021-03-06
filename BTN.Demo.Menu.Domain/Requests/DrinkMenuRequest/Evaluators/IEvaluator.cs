using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    /// <summary>
    /// Interface for evaluator instances of Drink Menu
    /// </summary>
    public interface IEvaluator
    {
        /// <summary>
        /// Evaluates a given aspect of a DrinkMenuContext
        /// </summary>
        /// <param name="context"></param>
        void Evaluate(DrinkMenuContext context);
    }
}
