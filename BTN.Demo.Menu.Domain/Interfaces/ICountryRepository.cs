using BTN.Demo.Menu.Domain.Entities;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Domain.Interfaces
{
    /// <summary>
    /// Interface for Country Repository
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Retrieves a country entity by given code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Country> GetCountry(string code);
    }
}
