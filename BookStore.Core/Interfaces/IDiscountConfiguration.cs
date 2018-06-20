namespace BookStore.Core.Interfaces
{
    internal interface IDiscountConfiguration
    {
        double GetDiscountRate(int booksQuantity);
    }
}