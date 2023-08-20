using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class BookReader
    {
        private Book book;
        private User user;
        private int pageNumber;
        public BookReader(Book book, User user, int lastPageRead = 1)
        {
            this.book = book;
            this.user = user;
            pageNumber = lastPageRead;
            
        }
        public void StartSession()
        {
            Console.WriteLine($"Current Page: {pageNumber}/{book.NumberOfPages}");
            Console.WriteLine(book[pageNumber - 1]);

            string key = "";
            Console.WriteLine("Menu: ");
            if (pageNumber == 1)
            {
                Console.WriteLine("\t1. Next Page");
                Console.WriteLine("\t2. Stop reading");
                key = Console.ReadLine();
                if(key == "2")
                {
                    key = "3";
                }
            }
            else if (pageNumber == book.NumberOfPages)
            {
                Console.WriteLine("\t1. Previous Page");
                Console.WriteLine("\t2. Stop reading");
                key = Console.ReadLine();
                if (key == "2")
                {
                    key = "3";
                }
                else if(key == "1")
                {
                    key = "2";
                }
            }
            else
            {
                Console.WriteLine("\t1. Next Page");
                Console.WriteLine("\t2. Previous Page");
                Console.WriteLine("\t3. Stop reading");
                key = Console.ReadLine();
            }

            
            switch (key)
            {
                case "1":
                    pageNumber++;
                    StartSession();
                    break;  
                case "2":
                    pageNumber--;
                    StartSession();
                    break;
                case "3":
                    user.Sessions[book.Title] = new Session(book, pageNumber, DateTime.Now); //Stop reading and add new session in the history of the user
                    break;
            }
        }


    }
}
