using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    /// <summary>
    /// Builder for evaluators
    /// </summary>
    public static class RequestBuilder
    {
        /// <summary>
        /// Create a List of Evaluators based on single given evaluator
        /// </summary>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public static List<IEvaluator> FromSingleEvaluator(this IEvaluator evaluator)
        {
            evaluator.ValidateNotNull(nameof(evaluator));

            return new List<IEvaluator>() { evaluator };
        }
    }
}
