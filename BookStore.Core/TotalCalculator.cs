using System;
using System.Collections.Generic;

namespace BookStore.Core
{
    public class TotalCalculator
    {
        private const int UNIT_PRICE = 42;

        public double CalculateTotal(IList<Book> list)
        {
            var booksQuantity = list.Count;

            var discountRate = GetDiscountRate(booksQuantity);
            var subtotal = (booksQuantity * UNIT_PRICE);
            var totalWithDiscount = subtotal - subtotal * discountRate;
            return totalWithDiscount;
        }

        private double GetDiscountRate(int howManyBooks)
        {
            if (howManyBooks >= 5) return 0.20;
            if (howManyBooks == 4) return 0.15;
            if (howManyBooks == 3) return 0.10;
            if (howManyBooks == 2) return 0.05;
            return 0;
        }
    }
}
