using BTN.Demo.Menu.Data.DbContext;
using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Data.Repositories
{
    /// <summary>
    /// Repository layer for Drink Entity
    /// </summary>
    public class DrinksRepository : IRepositoryDataSeeding<Drink>, IDrinksRepository
    {
        private readonly DrinkDbContext context;

        public DrinksRepository(DrinkDbContext context)
        {
            context.ValidateNotNull(nameof(context));

            this.context = context;
        }
        ///<inheritdoc cref="IDrinksRepository.GetDrinks"/>
        public async Task<IQueryable<Drink>> GetDrinks()
        {
            return await context.GetAll();
        }

        ///<inheritdoc cref="IRepositoryDataSeeding{T}.Reset"/>
        public async Task Reset()
        {
            await context.Reset();
        }

        ///<inheritdoc cref="IRepositoryDataSeeding{T}.Seed(IEnumerable{T})"/>
        public async Task Seed(IEnumerable<Drink> data)
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
