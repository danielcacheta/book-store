using BookStore.Core;
using System;
using System.Collections.Generic;

namespace BookStore.App
{
    class Program
    {
        private const string WELCOME_SCREEN = "W";
        private const string SELL_OPTION = "S";
        private const string EXIT_OPTION = "E";
        private const string COMPLETE_SELL = "C";
        private static IList<Book> cart;
        private static Inventory inventory;

        static void Main(string[] args)
        {
            PopulateInventory();

            var navigationOption = WELCOME_SCREEN;
            while (!navigationOption.Equals(EXIT_OPTION))
            {
                navigationOption = GetNavigationOption();
                if (navigationOption.Equals(SELL_OPTION))
                    SellBooks();
            }
        }

        private static void PopulateInventory()
        {
            inventory = new Inventory
            {
                Books = new List<Book>()
            };

            for (int i = 0; i < 7; i++)
            {
                inventory.Books.Add(new Book
                {
                    Name = "Book " + (i + 1),
                    Author = "Author " + (i + 1)
                });
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
            cart = new List<Book>();
            ListAvailableBooks();

            var sellingBookOption = WELCOME_SCREEN;
            while (!sellingBookOption.Equals(COMPLETE_SELL))
            {
                sellingBookOption = Console.ReadLine().ToUpper();
                if (sellingBookOption.Equals(COMPLETE_SELL)) break;

                if (!int.TryParse(sellingBookOption, out int selectedBookNumber)
                    || SelectedBookDoesNotExist(selectedBookNumber))
                {
                    Console.WriteLine("Unable to sell the specified book");
                    return;
                }

                AddBookToCart(inventory.Books[selectedBookNumber - 1]);
                ListBooksAddedToCart();
            }

            CalculateTotal(cart);
        }

        private static void ListAvailableBooks()
        {
            Console.Clear();
            Console.WriteLine("Which books have been sold?");
            Console.WriteLine("C - Completed, when you included all the books sold to this customer");

            ListBooks(inventory.Books);
        }

        private static void ListBooksAddedToCart()
        {
            Console.Clear();
            ListAvailableBooks();
            Console.WriteLine();
            Console.WriteLine("Books added to cart:");
            ListBooks(cart);
        }

        private static void AddBookToCart(Book book)
        {
            cart.Add(book);
        }

        private static bool SelectedBookDoesNotExist(int selectedBookNumber)
        {
            return selectedBookNumber > inventory.Books.Count;
        }

        private static void CalculateTotal(IList<Book> cart)
        {
            Console.WriteLine(cart.Count + " Books. Total Value = " + "{0:C}", new TotalCalculator().CalculateTotal(cart));
        }

        private static void ListBooks(IList<Book> books)
        {
            var listId = 1;
            foreach (var item in books)
            {
                Console.WriteLine(listId + " - " + item.Name + " - " + item.Author);
                listId++;
            }
        }

    }
}
