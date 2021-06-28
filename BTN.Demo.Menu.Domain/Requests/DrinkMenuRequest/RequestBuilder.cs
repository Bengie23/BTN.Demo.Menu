using BTN.Demo.Menu.Domain.Entities;
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
        /// Creates required Evaluator for Drink Menu Request for Customer By CustomerAge
        /// </summary>
        /// <returns></returns>
        public static IEvaluator BuildDrinkMenuRequestForCustomerByCustomerAge()
        {
            return new AgeEvaluator();
        }

        /// <summary>
        /// Creates required Evaluator for Drink Menu Request for InStock Items
        /// </summary>
        /// <returns></returns>
        public static IEvaluator BuildDrinkMenuRequestForInStockItems()
        {
            return new StockEvaluator();
        }

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
        public static DrinkMenuContext WithContext(this List<IEvaluator> evaluationGroup, IQueryable<Drink> drinks, int customerAge)
        {
            return new DrinkMenuContext(drinks, customerAge) 
            {
                Evaluators = evaluationGroup
            };
        }

        public static DrinkMenuContext WithContext(this List<IEvaluator> evaluationGroup, IQueryable<Drink> drinks, int customerAge, bool evaluateInStock)
        {
            return new DrinkMenuContext(drinks, customerAge, evaluateInStock)
            {
                Evaluators = evaluationGroup
            };
        }

        public static DrinkMenuContext WithContext(this List<IEvaluator> evaluationGroup, IQueryable<Drink> drinks,bool evaluateInStock)
        {
            return new DrinkMenuContext(evaluateInStock)
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
    }
}
