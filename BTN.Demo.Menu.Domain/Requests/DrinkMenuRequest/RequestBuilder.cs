using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
using BTN.Demo.Menu.Domain.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest
{
    /// <summary>
    /// Builder for Drink Menu Requests
    /// </summary>
    public static class RequestBuilder
    {
        /// <summary>
        /// Create a List of Evaluators based on single given evaluator
        /// </summary>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public static List<IEvaluator> FromSingleEvaluator(this IEvaluator evaluator)
        {
            evaluator.ValidateNotNull(nameof(evaluator));

            return new List<IEvaluator>() { evaluator };
        }

        /// <summary>
        /// Creates a Drink Menu Context for given variables and adds required Evaluators
        /// </summary>
        /// <param name="evaluationGroup"></param>
        /// <param name="drinks"></param>
        /// <param name="customerAge"></param>
        /// <returns></returns>
        public static DrinkMenuContext WithContext(this List<IEvaluator> evaluationGroup, IQueryable<Drink> drinks, int customerAge, Country country)
        {

            return new DrinkMenuContext(drinks, BuildProperties(customerAge, country)) 
            {
                Evaluators = evaluationGroup
            };
        }

        /// <summary>
        /// Creates a Drink Menu Context for given variables and adds required Evaluators
        /// </summary>
        /// <param name="evaluationGroup"></param>
        /// <param name="drinks"></param>
        /// <param name="customerAge"></param>
        /// <returns></returns>
        public static DrinkMenuContext WithContext(this List<IEvaluator> evaluationGroup, IQueryable<Drink> drinks, Country country)
        {
            //Empty dictionary means evaluators are agnostic
            return new DrinkMenuContext(drinks, BuildProperties(null,country))
            {
                Evaluators = evaluationGroup
            };
        }

        /// <summary>
        /// Executes all Evaluators for given Drink Menu Context
        /// </summary>
        /// <param name="drinkMenuContext"></param>
        /// <returns></returns>
        public static DrinkMenuContext Evaluate(this DrinkMenuContext drinkMenuContext)
        {
            foreach (var item in drinkMenuContext.Evaluators)
            {
                item.Evaluate(drinkMenuContext);
            }

            return drinkMenuContext;
        }

        private static Dictionary<string, object> BuildProperties(int? customerAge = null, Country country = null)
        {
            var properties = new Dictionary<string, object>();
            
            if (customerAge.HasValue)
            {
                properties.Add(AgeEvaluator.CustomerAgeKey, customerAge.Value);
            }

            if (country != null)
            {
                properties.Add(CountryEvaluator.CountryKey, country);
            }

            return properties;
        }

    }
}
