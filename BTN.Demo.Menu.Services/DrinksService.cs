using BTN.Demo.Menu.Domain.Interfaces;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
using BTN.Demo.Menu.Domain.Validation;
using BTN.Demo.Menu.Infra.Configuration;
using BTN.Demo.Menu.Services.Dto;
using BTN.Demo.Menu.Services.Dto.Transformers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Services
{
    /// <summary>
    /// Service to provide Drinks Menu
    /// </summary>
    public class DrinksService : IDrinksService
    {
        private readonly IDrinksRepository drinksRepo;
        private readonly ICountryRepository countryRepo;
        private readonly IEnumerable<IEvaluator> evaluators;
        private readonly CountryConfigurationOptions countryConfiggurationOptions;

        public DrinksService(IDrinksRepository drinksRepo, ICountryRepository countryRepository, IEnumerable<IEvaluator> evaluators, CountryConfigurationOptions countryConfigurationOptions)
        {
            drinksRepo.ValidateNotNull(nameof(drinksRepo));
            countryRepository.ValidateNotNull(nameof(countryRepository));
            evaluators.ValidateNotNull(nameof(evaluators));
            countryConfigurationOptions.ValidateNotNull(nameof(countryConfigurationOptions));

            this.drinksRepo = drinksRepo;
            this.countryRepo = countryRepository;
            this.evaluators = evaluators;
            this.countryConfiggurationOptions = countryConfigurationOptions;
        }

        public async Task<IQueryable<DrinkDto>> GetDrinksMenu()
        {
            var country = await countryRepo.GetCountry(countryConfiggurationOptions.CountryCode);

            var allDrinks = await drinksRepo.GetDrinks();

            var context = evaluators.Select<CountryEvaluator>()
                                        .FromSingleEvaluator()
                                        .WithContext(allDrinks,country)
                                        .Evaluate();

            return context.Data.AsExternalDrinks();
        }

        ///<inheritdoc cref="IDrinksRepository.GetDrinks"/>
        public async Task<IQueryable<DrinkDto>> GetDrinksMenuForCustomer(int customerAge)
        {
            var country = await countryRepo.GetCountry(countryConfiggurationOptions.CountryCode);

            customerAge.ValidateGreaterThanZero(nameof(customerAge));

            var allDrinks = await drinksRepo.GetDrinks();

            //simple way, business logic out of domain layer
            //return allDrinks.Where(x => customerAge > x.AvailableAtAge).AsExternalDrinks();

            //moving business logic to domain layer
            var evaluatorsToUse = new List<IEvaluator>();
            evaluatorsToUse.Add(evaluators.Select<CountryEvaluator>());
            evaluatorsToUse.Add(evaluators.Select<AgeEvaluator>());

            var context = evaluatorsToUse.WithContext(allDrinks, customerAge,country)
                                    .Evaluate();

            return context.Data.AsExternalDrinks();
        }

        public async Task<IQueryable<DrinkDto>> GetInStockDrinksMenu()
        {
            var country = await countryRepo.GetCountry(countryConfiggurationOptions.CountryCode);

            var allDrinks = await drinksRepo.GetDrinks();

            var evaluatorsToUse = new List<IEvaluator>();
            evaluatorsToUse.Add(evaluators.Select<StockEvaluator>());
            evaluatorsToUse.Add(evaluators.Select<CountryEvaluator>());

            var context = evaluatorsToUse.WithContext(allDrinks,country)
                                    .Evaluate();

            return context.Data.AsExternalDrinks();
        }

        public async Task<IQueryable<DrinkDto>> GetInStockDrinksMenuForCustomer(int customerAge)
        {
            var country = await countryRepo.GetCountry(countryConfiggurationOptions.CountryCode);

            var allDrinks = await drinksRepo.GetDrinks();

            var evaluatorsToUse = new List<IEvaluator>();
            evaluatorsToUse.Add(evaluators.Select<CountryEvaluator>());
            evaluatorsToUse.Add(evaluators.Select<StockEvaluator>());
            evaluatorsToUse.Add(evaluators.Select<AgeEvaluator>());

            var context = evaluatorsToUse.WithContext(allDrinks, customerAge,country)
                                    .Evaluate();

            return context.Data.AsExternalDrinks();
        }
    }
}
