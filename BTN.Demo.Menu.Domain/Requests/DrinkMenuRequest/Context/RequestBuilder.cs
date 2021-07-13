using BTN.Demo.Menu.Domain.Entities;
using BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators;
using System.Collections.Generic;
using System.Linq;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Context
{
    /// <summary>
    /// Builder for DrinkMenuContext
    /// </summary>
    public static class RequestBuilder
    {
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
            return new DrinkMenuContext(drinks, BuildProperties(null, country))
            {
                Evaluators = evaluationGroup
            };
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
