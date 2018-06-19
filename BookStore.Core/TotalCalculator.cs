using System;

namespace BookStore.Core
{
    public class TotalCalculator
    {
        private const int UNIT_PRICE = 42;
        private const string ARGUMENT_EXCEPTION_MESSAGE = "This is not a valid number of books sold";

        public double CalculateTotal(int howManyBooks)
        {
            if (howManyBooks < 0) throw new ArgumentException(ARGUMENT_EXCEPTION_MESSAGE);
            var discount = CalculateDiscountRate(howManyBooks);
            return (howManyBooks * UNIT_PRICE) - (discount * (howManyBooks * UNIT_PRICE));
        }

        private double CalculateDiscountRate(int howManyBooks)
        {
            if (howManyBooks >= 5) return 0.20;
            if (howManyBooks == 4) return 0.15;
            if (howManyBooks == 3) return 0.10;
            if (howManyBooks == 2) return 0.05;
            return 0;
        }
    }
}
