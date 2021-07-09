using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    /// <summary>
    /// Represents the variables of a context to be evaluated
    /// </summary>
    public class DrinkMenuContext : BaseRequestContext
    {
        private Dictionary<string, object> properties;

        public IQueryable<Drink> Data { get; set; }


        public DrinkMenuContext(IQueryable<Drink> data, Dictionary<string,object> properties)
        {
            data.ValidateNotNull(nameof(data));

            this.Data = data;
            this.properties = properties;
        }

        public object this[string key]
        {
            get
            {
                if (properties.ContainsKey(key))
                {
                    return properties[key];
                }

                return null;
            }
            set
            {
                //properties must be immutable
                if (!properties.ContainsKey(key))
                {
                    properties.TryAdd(key, value);
                }
            }
        }
    }
}
