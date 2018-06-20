using BookStore.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BookStore.Core.Tests
{
    [TestClass]
    public class TotalCalculatorTests
    {
        [DataTestMethod]
        [DataRow(1, 42, Category.Math)]
        [DataRow(1, 42, Category.ScienceFiction)]
        [DataRow(2, 79.80, Category.Math)]
        [DataRow(2, 71.40, Category.ScienceFiction)]
        [DataRow(3, 113.40, Category.Math)]
        [DataRow(3, 100.80, Category.ScienceFiction)]
        [DataRow(4, 142.80, Category.Math)]
        [DataRow(4, 117.60, Category.ScienceFiction)]
        [DataRow(5, 168, Category.Math)]
        [DataRow(5, 126, Category.ScienceFiction)]
        [DataRow(8, 268.80, Category.Math)]
        [DataRow(8, 201.60, Category.ScienceFiction)]
        public void MustCalculateTotalBasedOnNumberOfBooksSold(int quantitySold, double expectedTotal, Category bookCategory)
        {
            var sut = new TotalCalculator();
            var result = sut.CalculateTotal(GenerateListWith(quantitySold, bookCategory));

            Assert.AreEqual(expectedTotal, result);
        }

        [TestMethod]
        public void MustCalculateTotalCombiningSciFiCategoryAndOtherCategories()
        {
            var sut = new TotalCalculator();
            var completeList = new List<Book>();
            completeList.AddRange(GenerateListWith(3, Category.ScienceFiction));
            completeList.AddRange(GenerateListWith(5, Category.Math));

            var result = sut.CalculateTotal(completeList);
            Assert.AreEqual(268.80, result);
        }

        private static IList<Book> GenerateListWith(int length, Category category)
        {
            IList<Book> list = new List<Book>();
            for (int i = 0; i < length; i++)
            {
                list.Add(new Book
                {
                    Name = "Name " + i + 1,
                    Author = "Author " + i + 1,
                    Category = category
                });
            }
            return list;
        }
    }
}
