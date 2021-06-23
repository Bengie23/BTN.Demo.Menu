using System;

namespace BTN.Demo.Menu.Domain.Validation
{
    /// <summary>
    /// Validation helper class
    /// </summary>
    public static class ArgumentChecks
    {
        /// <summary>
        /// Evaluates a given argument. Throws when argument is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="name"></param>
        public static void ValidateNotNull<T>(this T argument, string name)
        {
            if (argument != null)
            {
                return;
            }

            throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Evaluates a given argument. Throws when argument is not greater than zero.
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="name"></param>
        public static void ValidateGreaterThanZero(this int argument, string name)
        {
            if (argument > 0)
            {
                return;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
