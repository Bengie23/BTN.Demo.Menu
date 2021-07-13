using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context;
using System;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    /// <summary>
    /// Base class for Evaluators
    /// </summary>
    public abstract class BaseEvaluator
    {
        /// <summary>
        /// Returns property from Context based on given key. Throws exception when key not found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
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
