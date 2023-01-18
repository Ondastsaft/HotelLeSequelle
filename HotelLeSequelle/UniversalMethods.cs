using HotelLeSequelle.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelLeSequelle
{
    internal class UniversalMethods
    {
        public static int TryParseReadKey(int spanLow, int spanHigh)
        {
            int key = 0;
            bool success = false;
            while (!success)
            {
                Console.WriteLine($"Enter Choice between {spanLow} and {spanHigh}");
                success = int.TryParse(Console.ReadKey().KeyChar.ToString(), out key);
                if (key < spanLow || key < spanHigh)
                {
                    success = false;
                }
                if (!success)
                {
                    Console.WriteLine("Incorrect entry!");
                    Console.WriteLine("Please try again");
                    Thread.Sleep(2000);
                    int cursorLeft;
                    int cursorTop;
                    (cursorLeft, cursorTop) = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorLeft, cursorTop - 2);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            return key;
        }
        public static int TryParseReadKey()
        {
            int key = 0;
            bool success = false;
            while (!success)
            {

                success = int.TryParse(Console.ReadKey().KeyChar.ToString(), out key);

                if (!success)
                {
                    Console.WriteLine("Incorrect entry!");
                    Console.WriteLine("Please try again");
                    Thread.Sleep(2000);
                    int cursorLeft;
                    int cursorTop;
                    (cursorLeft, cursorTop) = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorLeft, cursorTop - 2);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            return key;
        }
        public static int TryParseReadLine()
        {
            int entry = 0;
            bool success = false;
            while (!success)
            {
                success = int.TryParse(Console.ReadLine(), out entry);

                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(2);
                }
            }
            return entry;
        }
        public static void ClearAboveCursor(int linesToClear)
        {
            int cursorLeft;
            int cursorTop;
            (cursorLeft, cursorTop) = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorLeft, cursorTop - linesToClear);
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void IncorrectEntryMessage()
        {
            Console.WriteLine("Incorrect entry!");
            Console.WriteLine("Please try again");
            Thread.Sleep(1500);

        }
        public static void TruncateAllTables()
        {
            using (var context = new HotelLeSequelleContext())
            {
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Reservation]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Customer]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Receptionist]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Waiter]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Room]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[SideOrder]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Floor]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Product]");
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[SideOrderProduct]");
            }
        }
        public static void DeleteAllTables()
        {
            using (var context = new HotelLeSequelleContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[SideOrders]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Reservations]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[SideOrderProduct]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Products]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Customers]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Staff]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Rooms]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Floors]");
                context.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Hotels]");


            }
        }
        public static void AddTestPersons()
        {
            var customer = new Customer()
            {
                SirName = "John",
                LastName = "Doe",
                StreetAdress = "123 Main St",
                Locality = "New York",
                ZipCode = "12345",
                PhoneNumber = "123-456-7890",
                UserName = "JohnDoe",
                Password = "1234",
                Email = "",
                CardDetails = "5521 4532 5678 2341, 421, 05/24 John Doe",
                Nationality = "USA"
            };
            var waiter = new Waiter()
            {
                UserName = "Waiter",
                Password = "Waiter1",
                SirName = "Mike",
                LastName = "Tyson",
                StreetAdress = "Home",
                EmployeeNumber = 1,
                Locality = "Sweden",
                Email = "a@a.com",
                PhoneNumber = "123-456-7890",
                ZipCode = "12345",
                DateOfEmployment = new DateTime(2019, 1, 1),
                Nationality = "USA"
            };
            var receptionist = new Receptionist()
            {
                UserName = "Receptionist",
                Password = "Receptionist1",
                SirName = "Eric",
                LastName = "Magnusson",
                StreetAdress = "Home",
                EmployeeNumber = 2,
                Locality = "Sweden",
                Email = "",
                PhoneNumber = "123-456-7890",
                ZipCode = "12345",
                DateOfEmployment = new DateTime(2019, 1, 1),
                Nationality = "USA"
            };
            using (var db = new HotelLeSequelleContext())
            {
                db.Customers.Add(customer);
                db.Waiters.Add(waiter);
                db.Receptionists.Add(receptionist);
                db.SaveChanges();
            }
        }
        public static void AddTestProducts()
        {
            var product1 = new Product()
            {
                Name = "Burger",
                Price = 100,
                Stock = 10,
            };
            var product2 = new Product()
            {
                Name = "Fries",
                Price = 50,
                Stock = 10,
            };
            var product3 = new Product()
            {
                Name = "Coke",
                Price = 25,
                Stock = 10,
            };
            var product4 = new Product()
            {
                Name = "2 bed room",
                Price = 200,
            };
            var product5 = new Product()
            {
                Name = "Single bed room",
                Price = 150,
            };
            using (var db = new HotelLeSequelleContext())
            {
                db.Products.Add(product1);
                db.Products.Add(product2);
                db.Products.Add(product3);
                db.Products.Add(product4);
                db.Products.Add(product5);
                db.SaveChanges();
            }
        }
        public static void LogInCustomer()
        {
            Console.WriteLine("Please enter your username");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            using (var db = new HotelLeSequelleContext())
            {
                try
                {
                    var customer = db.Customers.FirstOrDefault(c => c.UserName == userName && c.Password == password);
                    if (customer != null)
                    {
                        Program.LoggedInUser = customer;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect username or password");
                    Thread.Sleep(1500);
                    return;
                }

            }
        }
        public static void LogInStaff()
        {
            Console.WriteLine("Please enter your username");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            using (var db = new HotelLeSequelleContext())
            {
                try
                {
                    var staff = db.Receptionists.FirstOrDefault(s => s.UserName == userName && s.Password == password);
                    if (staff != null)
                    {
                        Program.LoggedInUser = staff;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect username or password");
                    Thread.Sleep(1500);
                    return;
                }
            }
        }
        public static void LogInAdmin()
        {
            Console.WriteLine("Please enter your username");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            using (var db = new HotelLeSequelleContext())
            {
                try
                {
                    var admin = db.Administrators.FirstOrDefault(a => a.Name == userName && a.Password == password);
                    if (admin != null)
                    {
                        Program.LoggedInAdmin = admin;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect username or password");
                    Thread.Sleep(1500);
                    return;
                }
            }
        }
        public static void SearchAvailableRooms()
        {
            Console.WriteLine("Please enter the date you want to check in");
            DateTime checkInDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date you want to check out");
            DateTime checkOutDate = DateTime.Parse(Console.ReadLine());
            using (var db = new HotelLeSequelleContext())
            {
                var availableRooms = db.Rooms.Where(r => r.Reservations.All(res => res.CheckInDate > checkOutDate || res.CheckOutDate < checkInDate)).ToList();
                foreach (var room in availableRooms)
                {
                    Console.WriteLine(room.RoomNumber);
                }
            }
        }
        public static void RegisterNewCustomer()
        {
            var customer = new Customer();
            Console.WriteLine("Please enter your first name");
            customer.SirName = Console.ReadLine();
            Console.WriteLine("Please enter your last name");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Please enter your street adress");
            customer.StreetAdress = Console.ReadLine();
            Console.WriteLine("Please enter your zip code");
            customer.ZipCode = Console.ReadLine();
            Console.WriteLine("Please enter your locality");
            customer.Locality = Console.ReadLine();
            Console.WriteLine("Please enter your phone number");
            customer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter your email adress");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Please enter your username");
            customer.UserName = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            customer.Password = Console.ReadLine();
            var db = new HotelLeSequelleContext();
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        public static void Menu()
        {
            Console.Clear();
            List<Action> menuList = new List<Action>() { SearchAvailableRooms, RegisterNewCustomer, LogInCustomer };
            Console.WriteLine("Welcome to Hotel Le Sequelle");
            Console.WriteLine("Please select an option");
            foreach (var item in menuList)
            {
                Console.WriteLine($"[{menuList.IndexOf(item) + 1}] {item.Method.Name}");
            }
            int choice = TryParseReadKey(1, 3);
            switch (choice)
            {
                case 1:
                    SearchAvailableRooms();
                    break;
                case 2:
                    RegisterNewCustomer();
                    break;
                case 3:
                    LogInCustomer();
                    Program.LoggedInUser.Menu();
                    break;
                case 9:
                    LogInAdmin();
                    Program.LoggedInAdmin.Menu();
                    break;
                case 0:
                    LogInStaff();
                    Program.LoggedInUser.Menu();
                    break;
                default:
                    break;

            }
        }
    }
}

