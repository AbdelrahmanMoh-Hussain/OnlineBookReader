using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    public delegate void BookAddHandelr(string bookTitle);
    internal class Admin
    {
        public static List<Book> AvailableBooks { get; set; } = new List<Book>();
        public event BookAddHandelr BookAdded;
        public void AddBook()
        {
            Console.Write("Enter ISBN: ");
            var isbn = Console.ReadLine();
            Console.Write("Enter Title: ");
            var title = Console.ReadLine();
            Console.Write("Enter Author Name: ");
            var autorName = Console.ReadLine();
            Console.Write("Enter How many pages: ");
            var numberOfPages = int.Parse(Console.ReadLine());
            string[] pages = new string[numberOfPages];
            for (int i = 0; i < numberOfPages; i++)
            {
                Console.Write($"Enter page # {i + 1}: ");
                pages[i] = Console.ReadLine();
            }

            Book book = new Book(isbn, title, autorName, numberOfPages, pages);
            AvailableBooks.Add(book);
            if(BookAdded != null)
            {
                BookAdded(title);
            }
        }
    }
}
