using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Book_Reader
{
    internal class User
    {
        
        private string userName;
        private string password;
        private string name;
        private string email;

        public User(string userName, string password, string name, string email)
        {
            this.userName = userName;
            this.password = password;
            this.name = name;
            this.email = email;
            Sessions = new Dictionary<string, Session>();
        }

        public string UserName { get { return userName; } }
        public string Password { get { return password; } }
        public Dictionary<string, Session> Sessions { get; set; }

        public void ViewProfile()
        {
            Console.WriteLine(this);
        }

        public void OpenAvailableBooks()
        {
            if(Admin.AvailableBooks.Count == 0) //No books yet
            {
                Console.WriteLine("There is no books Available right now, please vist us later");
                return;
            }
            Console.WriteLine("Our current book collections");
            for (int i = 0; i < Admin.AvailableBooks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Admin.AvailableBooks[i].Title}"); //OUTPUT EX: 1. Head first to Java
            }

            Console.WriteLine("Which book to read?");
            Console.Write($"Enter number in range 1 - {Admin.AvailableBooks.Count}: ");
            var bookChoice = int.Parse(Console.ReadLine());

            BookReader reader = new BookReader(Admin.AvailableBooks[bookChoice - 1], this);
            reader.StartSession();
        }

        public void OpenReadingHistory()
        {
            if (Sessions.Count == 0) //no history to show
            {
                Console.WriteLine("There is no History, Do you want to read a new book [\'Y\' - \'N\']");
                var key = Console.ReadLine();
                if(key == "Y" || key == "y")
                {
                    OpenAvailableBooks();
                }
                return;
            }
            var index = 0;
            foreach(var session in Sessions) 
            {
                Console.WriteLine($"{index + 1}. {session.Value}"); //OUTPUT ex: 1. Head first to Java: 50/324 - 2023/8/6 10:53:00
            }

            Console.WriteLine("Which session to open?");
            Console.Write($"Enter number in range 1 - {Sessions.Count}: ");
            var sessionChoice = int.Parse(Console.ReadLine());

            index = 0;
            foreach (var session in Sessions)
            {
                if(index == sessionChoice)
                {
                    BookReader reader = new BookReader(session.Value.Book, this, session.Value.NumberOfPagesRead);
                    reader.StartSession();
                    break;
                }
            }
        }

        /*OUTPUT EXAMPLE
         *User Name: Ahmed350
         *Email: ahmed@test.com
         *Name: Ahmed Ali"; 
         */
        public override string ToString()
        {
            return $"User Name: {this.userName}" +
                   $"\nEmail: {this.email}" +
                   $"\nName: {this.name}";
        }
    }
}
