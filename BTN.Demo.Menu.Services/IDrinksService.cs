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
        /// Retrieves a drink menu for given customer age
        /// </summary>
        /// <param name="customerAge"></param>
        /// <returns></returns>
        Task<IQueryable<DrinkDto>> GetDrinksMenuForCustomer(int customerAge);

        /// <summary>
        /// Retrieves a drink menu for In-Stock Items
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<DrinkDto>> GetInStockDrinksMenu();

        /// <summary>
        /// Retrieves a drink menu for In-Stokc Items and given customer age
        /// </summary>
        /// <param name="customerAge"></param>
        /// <returns></returns>
        Task<IQueryable<DrinkDto>> GetInStockDrinksMenuForCustomer(int customerAge);

        /// <summary>
        /// Retrieves a drink menu with all drinks
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<DrinkDto>> GetDrinksMenu();
    }
}
