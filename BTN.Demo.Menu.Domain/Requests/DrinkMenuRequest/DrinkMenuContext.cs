using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Validation;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    /// <summary>
    /// Represents the variables of a context to be evaluated
    /// </summary>
    public class DrinkMenuContext : BaseRequestContext
    {
        public int CustomerAge { get; set; }
        public IQueryable<Drink> Data { get; set; }


        public DrinkMenuContext(IQueryable<Drink> data, int customerAge)
        {
            data.ValidateNotNull(nameof(data));
            customerAge.ValidateGreaterThanZero(nameof(customerAge));

            this.Data = data;
            this.CustomerAge = customerAge;
        }

        public bool EvaluateStock { get; set; }

        public DrinkMenuContext(bool ignoreOutOfStockItems)
        {
            this.EvaluateStock = ignoreOutOfStockItems;
        }

        public DrinkMenuContext(IQueryable<Drink> data, int customerAge, bool ignoreOutOfStockItems) : this(data,customerAge)
        {
            this.EvaluateStock = ignoreOutOfStockItems;
        }
    }
}
