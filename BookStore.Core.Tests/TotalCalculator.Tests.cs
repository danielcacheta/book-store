using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        public void MustCalculateTotalBasedOnNumberOfBooksSold(int quantitySold, double expectedTotal)
        {
            var sut = new TotalCalculator();
            var result = sut.CalculateTotal(GenerateListWith(quantitySold));

            Assert.AreEqual(expectedTotal, result);
        }

        private static IList<Book> GenerateListWith(int length)
        {
            IList<Book> list = new List<Book>();
            for (int i = 0; i < length; i++)
            {
                list.Add(new Book
                {
                    Name = "Name " + i + 1,
                    Author = "Author " + i + 1
                });
            }
            return list;
        }
    }
}
