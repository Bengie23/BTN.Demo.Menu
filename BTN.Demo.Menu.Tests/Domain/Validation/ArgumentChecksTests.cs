using BTN.Demo.Menu.Domain.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BTN.Demo.Menu.Tests.Domain.Validation
{
    [TestClass]
    public class ArgumentChecksTests
    {
        [TestMethod]
        public void ValidateNotNull_DoesNothing_When_NotNullArgument()
        {
            var test = new { Test = "test" };
            test.ValidateNotNull(nameof(test));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNotNull_Throws_When_NullArgument()
        {
            object test = null;
            test.ValidateNotNull(nameof(test));
        }

        [TestMethod]
        public void ValidateGreaterThanZero_DoesNothing_When_ValidArgument()
        {
            int number = 1;
            number.ValidateGreaterThanZero(nameof(number));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ValidateGreaterThanZero_Throws_When_NotValidArgument()
        {
            int number = 0;
            number.ValidateGreaterThanZero(nameof(number));

        }
    }
}
