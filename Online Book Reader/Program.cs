namespace Online_Book_Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ADMIN_USERNAME = "admin";
            const string ADMIN_PASSWORD = "0000";
            
            List<User> users = new List<User>();
            
            while (true)
            {
                PrintMainMenu();
                var key1 = Console.ReadLine();

                int userIndex = -1;
                Admin admin= new Admin();
                bool adminView = false;

                if (key1 == "1")
                {
                    Console.Write("Enter user name: ");
                    var userName = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var password = Console.ReadLine();
                    if (userName.ToLower() == ADMIN_USERNAME && password == ADMIN_PASSWORD)
                    {
                        adminView = true;
                        Console.WriteLine($"Hello, Mr.Admin | Admin View");
                    }
                    else
                    {
                        if(users.Count == 0)
                        {
                            Console.WriteLine("We can't find your account, please Sign Up");
                            continue;
                        }
                        else
                        {
                            for (int i = 0; i < users.Count; i++)
                            {
                                if (users[i].UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && users[i].Password.Equals(password, StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.WriteLine($"Hello, {userName} | User View");
                                    userIndex = i;
                                    break;
                                }
                            }
                        }
                    }

                }
                else if (key1 == "2")
                {
                    Console.Write("Enter user name: ");
                    var userName = Console.ReadLine();
                    Console.Write("Enter password: ");
                    var password = Console.ReadLine();
                    Console.Write("Enter name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter email: ");
                    var email = Console.ReadLine();

                    Console.WriteLine($"Hello, {userName} | User View");
                    users.Add(new User(userName, password, name, email));
                    userIndex = users.Count - 1;
                }
                else if (key1 == "3")
                {
                    break;
                }
                else //Enterd wrong choice not from 1 - 3
                {
                    continue; //Repate choosing
                }

                //Admin options
                if (adminView)
                {
                    while (true)
                    {
                        PrintAdminMenu();
                        var key2 = Console.ReadLine();

                        if(key2 == "1")
                        {
                            admin.BookAdded += Admin_BookAdded;
                            admin.AddBook();
                        }
                        else if(key2 == "2")
                        {
                            break;
                        }
                    }
                }
                else //Users options
                {
                    while (true)
                    {
                        PrintUserMenu();
                        var key3 = Console.ReadLine();

                        if (key3 == "1")
                        {
                            users[userIndex].ViewProfile();
                        }
                        else if (key3 == "2")
                        {
                            users[userIndex].OpenReadingHistory();
                        }
                        else if (key3 == "3")
                        {
                            users[userIndex].OpenAvailableBooks();
                        }
                        else if (key3 == "4")
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static void Admin_BookAdded(string bookTitle)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"New Book Added!! Book Title: {bookTitle}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        #region Options Menus
        static void PrintMainMenu()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("\t1. Login");
            Console.WriteLine("\t2. Sign Up");
            Console.WriteLine("\t3. Exit");
            Console.WriteLine("Enter number in range 1 - 3");
        }
        static void PrintUserMenu()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("\t1. View Profile");
            Console.WriteLine("\t2. Open my Reading history");
            Console.WriteLine("\t3. Open Available Books");
            Console.WriteLine("\t4. Logout");
            Console.WriteLine("Enter number in range 1 - 4");
        }
        static void PrintAdminMenu()
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("\t1. Add book");
            Console.WriteLine("\t2. Logout");
            Console.WriteLine("Enter number in range 1 - 2");
        }
        #endregion
    }
}