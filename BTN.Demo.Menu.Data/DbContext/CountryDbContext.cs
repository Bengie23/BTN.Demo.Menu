using BTN.Demo.Menu.Domain.Entities;

namespace BTN.Demo.Menu.Data.DbContext
{
    /// <summary>
    ///  Handles the access to persistance layer for Drink entities.
    /// </summary>
    public class CountryDbContext : FakeDbContext<Country>
    {
    }
}
