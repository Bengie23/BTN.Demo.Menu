using BTN.Demo.Menu.Services.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Services
{
    /// <summary>
    /// Interface for Drinks Service
    /// </summary>
    public interface IDrinksService
    {
        /// <summary>
        /// Retrieves a drink menu for given customer
        /// </summary>
        /// <param name="customerAge"></param>
        /// <returns></returns>
        Task<IQueryable<DrinkDto>> GetDrinksMenuForCustomer(int customerAge);
    }
}
