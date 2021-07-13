using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
using System.Collections.Generic;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context
{
    /// <summary>
    /// Base class for a context. Wrapper for evaluators in Context.
    /// </summary>
    public abstract class BaseRequestContext
    {
        public IEnumerable<IEvaluator> Evaluators { get; set; }

    }
}
