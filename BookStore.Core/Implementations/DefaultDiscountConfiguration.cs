using BookStore.Core.Interfaces;

namespace BookStore.Core.Implementations
{
    class DefaultDiscountConfiguration : IDiscountConfiguration
    {
        public double GetDiscountRate(int booksQuantity)
        {
            if (booksQuantity >= 5) return 0.20;
            if (booksQuantity == 4) return 0.15;
            if (booksQuantity == 3) return 0.10;
            if (booksQuantity == 2) return 0.05;
            return 0;
        }
    }
}
