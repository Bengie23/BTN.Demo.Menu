using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    /// <summary>
    /// Represents the variables of a context to be evaluated
    /// </summary>
    public class DrinkMenuContext
    {
        public int CustomerAge { get; set; }
        public IQueryable<Drink> Data { get; set; }

        public IEnumerable<IEvaluator> Evaluators { get; set; }


        public DrinkMenuContext(IQueryable<Drink> data, int customerAge)
        {
            data.ValidateNotNull(nameof(data));
            customerAge.ValidateGreaterThanZero(nameof(customerAge));

            this.Data = data;
            this.CustomerAge = customerAge;
        }
    }
}
