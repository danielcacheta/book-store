using BookStore.Core.Interfaces;

namespace BookStore.Core.Implementations
{
    class SciFiDiscountConfiguration : IDiscountConfiguration
    {
        public double GetDiscountRate(int booksQuantity)
        {
            if (booksQuantity >= 5) return 0.40;
            if (booksQuantity == 4) return 0.30;
            if (booksQuantity == 3) return 0.20;
            if (booksQuantity == 2) return 0.15;
            return 0;
        }
    }
}
