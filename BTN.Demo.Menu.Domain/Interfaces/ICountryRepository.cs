using BTN.Demo.Menu.Domain.Entities;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country> GetCountry(string code);
    }
}
