using BookStore.Core.Implementations;
using BookStore.Core.Interfaces;
using BookStore.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Core
{
    public class TotalCalculator
    {
        private const int UNIT_PRICE = 42;
        
        public double CalculateTotal(IList<Book> list)
        {
            var sciFiTotal = SumTotal(
                list.Where(l => l.Category == Category.ScienceFiction),
                new SciFiDiscountConfiguration());
            var nonSciFiTotal = SumTotal(
                list.Where(l => l.Category != Category.ScienceFiction),
                new DefaultDiscountConfiguration());

            return sciFiTotal + nonSciFiTotal;
        }

        private double SumTotal(IEnumerable<Book> listToSum, IDiscountConfiguration discountConfiguration)
        {
            var quantityToSum = listToSum.Count();

            var discountRate = discountConfiguration.GetDiscountRate(quantityToSum);
            var subtotal = (quantityToSum * UNIT_PRICE);
            var totalWithDiscount = subtotal - subtotal * discountRate;

            return totalWithDiscount;
        }
    }
}
