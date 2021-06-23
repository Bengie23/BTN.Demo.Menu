using BTN.Demo.Menu.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Domain.Interfaces
{
    /// <summary>
    /// Interface for Drinks Repository
    /// </summary>
    public interface IDrinksRepository
    {
        /// <summary>
        /// Retrieves the existing full list of drinks
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<Drink>> GetDrinks();
    }
}
