using System;

namespace BTN.Demo.Menu.Domain.Helper
{
    /// <summary>
    /// Extension class for Drink
    /// </summary>
    public static class DrinkExtensions
    {
        /// <summary>
        /// Generate a random boolean
        /// </summary>
        /// <returns></returns>
        public static bool RandomInStock()
        {
            bool inStock = false;
            Random r = new Random();
            int rInt = r.Next(0, 100);
            if (rInt > 50)
            {
                inStock = true;
            }

            return inStock;
        }
    }
}
