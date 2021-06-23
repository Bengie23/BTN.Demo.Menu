using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest;
using BTN.Demo.Menu.Domain.Validation;
using BTN.Demo.Menu.Services.Dto;
using BTN.Demo.Menu.Services.Dto.Transformers;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Services
{
    /// <summary>
    /// Service to provide Drinks Menu
    /// </summary>
    public class DrinksService : IDrinksService
    {
        private readonly IDrinksRepository repo;

        public DrinksService(IDrinksRepository repo)
        {
            repo.ValidateNotNull(nameof(repo));

            this.repo = repo;
        }
        ///<inheritdoc cref="IDrinksRepository.GetDrinks"/>
        public async Task<IQueryable<DrinkDto>> GetDrinksMenuForCustomer(int customerAge)
        {
            customerAge.ValidateGreaterThanZero(nameof(customerAge));

            var allDrinks = await repo.GetDrinks();

            //simple way, business logic out of domain layer
            //return allDrinks.Where(x => customerAge > x.AvailableAtAge).AsExternalDrinks();

            //moving business logic to domain layer
            var context = RequestBuilder.BuildDrinkMenuRequestForCustomerByCustomerAge()
                                        .FromSingleEvaluator()
                                        .WithContext(allDrinks, customerAge)
                                        .Evaluate();

            return context.Data.AsExternalDrinks();
        }
    }
}
