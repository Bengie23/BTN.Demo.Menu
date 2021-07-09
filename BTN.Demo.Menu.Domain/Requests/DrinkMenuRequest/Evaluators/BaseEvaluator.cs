using System;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    public abstract class BaseEvaluator
    {
        protected T GetProperty<T>(DrinkMenuContext context, string key)
        {
            object property = context[key];

            if (property != null)
            {
                if (property is T result)
                {
                    return result;
                }
            }

            throw new InvalidOperationException($"unable to capture property {key} from context");
        }
    }
}
