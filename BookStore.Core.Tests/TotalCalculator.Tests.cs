using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookStore.Core.Tests
{
    [TestClass]
    public class TotalCalculatorTests
    {
        [DataTestMethod]
        [DataRow(1, 42)]
        [DataRow(2, 79.80)]
        [DataRow(3, 113.40)]
        [DataRow(4, 142.80)]
        [DataRow(5, 168)]
        [DataRow(8, 268.80)]
        public void MustCalculateTotalBasedOnNumberOfBooks(int howManyBooks, double expectedTotal)
        {
            var sut = new TotalCalculator();
            var result = sut.CalculateTotal(howManyBooks);

            Assert.AreEqual(expectedTotal, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MustThrowExceptionForInvalidNumberOfBooks()
        {
            var sut = new TotalCalculator();
            var result = sut.CalculateTotal(-1);
        }
    }
}
