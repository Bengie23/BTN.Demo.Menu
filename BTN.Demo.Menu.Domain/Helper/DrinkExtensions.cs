using System;

namespace BTN.Demo.Menu.Domain.Helper
{
    public static class DrinkExtensions
    {
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
