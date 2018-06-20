using BookStore.Helpers;

namespace BookStore.Core
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
    }
}