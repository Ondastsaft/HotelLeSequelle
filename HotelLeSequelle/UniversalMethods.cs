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

    }
}
