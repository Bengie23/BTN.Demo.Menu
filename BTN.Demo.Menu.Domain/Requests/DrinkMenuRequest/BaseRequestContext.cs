using System.Collections.Generic;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    public abstract class BaseRequestContext
    {
        public IEnumerable<IEvaluator> Evaluators { get; set; }

    }
}
