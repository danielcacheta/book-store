using BookStore.Core;
using System;

namespace BookStore.App
{
    class Program
    {
        private const string WELCOME_SCREEN = "W";
        private const string SELL_OPTION = "S";
        private const string EXIT_OPTION = "E";

        static void Main(string[] args)
        {
            var navigationOption = WELCOME_SCREEN;
            while (!navigationOption.Equals(EXIT_OPTION))
            {
                navigationOption = GetNavigationOption();
                if (navigationOption.Equals(SELL_OPTION))
                    SellBooks();
            }
        }

        private static string GetNavigationOption()
        {
            Console.WriteLine();
            Console.WriteLine("##########################");
            Console.WriteLine();
            Console.WriteLine("Welcome to the Book Store!");
            Console.WriteLine("Select the option:");
            Console.WriteLine(SELL_OPTION + " - Sell Books");
            Console.WriteLine(EXIT_OPTION + " - Exit");
            return Console.ReadLine().ToUpper();
        }

        private static void SellBooks()
        {
            Console.WriteLine("How many books were sold?");
            if (!int.TryParse(Console.ReadLine(), out int howManyBooks))
            {
                Console.WriteLine("Unable to sell the specified quantity");
                return;
            }

            CalculateTotal(howManyBooks);
        }

        private static void CalculateTotal(int howManyBooks)
        {
            try
            {
                Console.WriteLine("Total Value = " + "{0:C}", new TotalCalculator().CalculateTotal(howManyBooks));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
