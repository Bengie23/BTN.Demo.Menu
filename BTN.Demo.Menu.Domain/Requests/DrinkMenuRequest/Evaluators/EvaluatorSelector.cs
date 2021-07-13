﻿using System.Collections.Generic;

namespace BTN.Demo.Menu.Domain.Requests.DrinkMenuRequest.Evaluators
{
    /// <summary>
    /// Helper class for selecting an evaluator from collection
    /// </summary>
    public static class EvaluatorSelector
    {
        /// <summary>
        /// Returns evaluator based on fiven type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="evaluators"></param>
        /// <returns></returns>
        public static IEvaluator Select<T>(this IEnumerable<IEvaluator> evaluators) where T : IEvaluator
        {
            IEvaluator result = null;

            foreach (var item in evaluators)
            {
                if (item is T)
                {
                    result = item;
                    break;
                }
            }

            return result;
        }
    }
}
