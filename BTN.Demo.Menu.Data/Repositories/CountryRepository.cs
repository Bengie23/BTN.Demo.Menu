using BTN.Demo.Menu.Data.DbContext;
using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Data.Repositories
{
    public class CountryRepository : IRepositoryDataSeeding<Country>, ICountryRepository
    {
        private readonly CountryDbContext context;

        public CountryRepository(CountryDbContext context)
        {
            context.ValidateNotNull(nameof(context));

            this.context = context;
        }
        public async Task<Country> GetCountry(string code)
        {
            var all = await context.GetAll();

            return all.FirstOrDefault(c => c.Code == code);
        }

        public async Task Reset()
        {
            await context.Reset();
        }

        public async Task Seed(IEnumerable<Country> data)
        {
            List<Task> tasks = new List<Task>();
            foreach (var drink in data)
            {
                tasks.Add(context.Create(drink));
            }

            await Task.WhenAll(tasks);
        }
    }
}
