using HotelLeSequelle.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelLeSequelle
{
    public static class UniversalMethods
    {
        public static List<Action> DevMenu = new List<Action>()
                {
                    TruncateAllTables,
                    DeleteAllTables,
                    PopulateDatabase,
                    LogInTestCustomer,
                    LogInTestReceptionist,
                    LogInTestWaiter,
                    LogInTestAdmin,
                    AddTestPersons,
                    AddTestProducts,
                    AddReservation,



                };
        public static List<Action> BaseMenu = new List<Action>()
        {
            LogInCustomer,
            LogInStaff,
            LogInAdmin,
            RegisterNewCustomer,
            SearchAvailableRooms,
            RunDev
        };
        public static Person LoggedInUser { get; set; }
        public static Administrator? LoggedInAdmin { get; set; }

        //Helpers
        public static int TryParseReadKey(int spanLow, int spanHigh)
        {
            int key = 0;
            bool success = false;
            while (!success)
            {
                Console.WriteLine($"Enter choise between {spanLow} and {spanHigh}");
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
        public static int TryParseReadLine(int spanLow, int spanHigh)
        {
            int key = 0;
            bool success = false;
            while (!success)
            {
                Console.WriteLine($"Enter choise between {spanLow} and {spanHigh}");
                success = int.TryParse(Console.ReadLine(), out key);
                if (key < spanLow && key < spanHigh)
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
        public static DateTime TryParseDateTime()
        {
            DateTime userEntry = DateTime.Now;
            bool success = false;
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out userEntry);

                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(2);
                }

            }
            return userEntry;
        }
        public static void TryParseDateTime(DateTime spanLow, DateTime spanHigh)
        {
            DateTime userEntry;
            bool success = false;
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out userEntry);

                if (userEntry < spanLow || userEntry > spanHigh)
                {
                    success = false;
                }
                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(1);
                }
            }
        }
        public static void TryParseDateTime(List<DateTime> unavailableDates)
        {
            DateTime userEntry;
            bool success = false;
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out userEntry);
                if (unavailableDates.Contains(userEntry))
                {
                    success = false;
                    Console.WriteLine("That date has already booked!");
                }
                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(1);
                }
            }
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
            ClearAboveCursor(2);

        }
        public static void PrintInMiddle(List<string> stringsToPrint)
        {
            foreach (var centeredString in stringsToPrint)
            {
                Console.SetCursorPosition(40, 3);
                Console.WriteLine(centeredString);
            }
        }
        public static void PrintInMiddle(string stringToPrint, int fromTop)
        {
            Console.SetCursorPosition(50, fromTop);
            Console.WriteLine(stringToPrint);
        }

        //Dev
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
        public static void PopulateDatabase()
        {
            AddTestHotel();
            AddTestProducts();
            AddTestPersons();
        }
        public static void AddReservation()
        {
            var reservation = new Reservation();
            Console.WriteLine("Please enter the room number you want to reserve");
            //int roomNumber = TryParseReadLine();
            int roomNumber = 303;
            using (var db = new HotelLeSequelleContext())
            {
                var room = db.Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
                if (room != null)
                {
                    //reservation.Room = room;
                }
                else
                {
                    Console.WriteLine("Room not found");
                    Thread.Sleep(1500);
                    return;
                }
            }
            //Console.WriteLine("Please enter the date you want to check in");
            //reservation.CheckInDate = DateTime.Parse(Console.ReadLine());
            //Console.WriteLine("Please enter the date you want to check out");
            //reservation.CheckOutDate = DateTime.Parse(Console.ReadLine());
            reservation.CheckInDate = DateTime.Parse("2023-02-01");
            reservation.CheckOutDate = DateTime.Parse("2023-02-02");
            //reservation.Customer = (Customer)UniversalMethods.LoggedInUser;
            using (var db = new HotelLeSequelleContext())
            {
                db.Rooms.Where(r => r.RoomNumber == roomNumber).SingleOrDefault().Reservations.Add(reservation);
                db.SaveChanges();
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
        public static void LogInTestCustomer()
        {
            using (var db = new HotelLeSequelleContext())
            {
                try
                {
                    var customer = db.Customers.FirstOrDefault();
                    if (customer != null)
                    {
                        UniversalMethods.LoggedInUser = customer;
                        (UniversalMethods.LoggedInUser as Customer).Run();
                    }
                }
                catch
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Clear();
                        UniversalMethods.PrintInMiddle("Error", 20);
                        Thread.Sleep(1500);
                    }

                }
            }
        }
        public static void LogInTestAdmin()
        {
            using (var db = new HotelLeSequelleContext())
            {
                try
                {
                    var admin = db.Administrators.FirstOrDefault();
                    if (admin != null)
                    {
                        UniversalMethods.LoggedInAdmin = admin;
                        UniversalMethods.LoggedInAdmin.Run();
                    }
                    else
                    {
                        Console.Clear();
                        for (int i = 0; i < 10; i++)
                        {
                            PrintInMiddle("No waiter in database", 20);
                            Thread.Sleep(500);
                            Console.Clear();
                            Thread.Sleep(500);
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        public static void LogInTestReceptionist()
        {

            using (var db = new HotelLeSequelleContext())
            {
                try
                {
                    var staff = db.Receptionists.FirstOrDefault();
                    if (staff != null)
                    {
                        UniversalMethods.LoggedInUser = staff;
                        UniversalMethods.LoggedInUser.Run();
                    }
                    else
                    {
                        Console.Clear();
                        for (int i = 0; i < 10; i++)
                        {
                            PrintInMiddle("No waiter in database", 20);
                            Thread.Sleep(500);
                            Console.Clear();
                            Thread.Sleep(500);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        PrintInMiddle("ERROR LOG IN TEST RECEPTIONIST", 20);
                        Thread.Sleep(500);
                        Console.Clear();
                        Thread.Sleep(500);
                    }

                }
            }
        }
        public static void LogInTestWaiter()
        {

            using (var db = new HotelLeSequelleContext())
            {
                try
                {
                    var staff = db.Waiters.FirstOrDefault();
                    if (staff != null)
                    {
                        UniversalMethods.LoggedInUser = staff;
                        UniversalMethods.LoggedInUser.Run();
                    }
                    else
                    {
                        Console.Clear();
                        for (int i = 0; i < 10; i++)
                        {
                            PrintInMiddle("No waiter in database", 20);
                            Thread.Sleep(500);
                            Console.Clear();
                            Thread.Sleep(500);
                        }
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        PrintInMiddle("ERROR LOG IN TEST Waiter", 20);
                        Thread.Sleep(500);
                        Console.Clear();
                        Thread.Sleep(500);
                    }

                }
            }
        }
        public static void AddTestHotel()
        {
            Hotel tempHotel = new Hotel();
            tempHotel.Name = "Hotel Le Sequelle";
            tempHotel.StreetAdress = "Kungsgatan 1";
            tempHotel.Locality = "Stockholm";
            tempHotel.Country = "Sweden";
            tempHotel.PhoneNumber = "08-1234567";
            tempHotel.ZipCode = "16101";
            tempHotel.Email = "info@hotellesequelle.com";
            tempHotel.WebPage = "www.hotellesequelle.com";
            Console.Clear();
            var Db = new HotelLeSequelleContext();
            tempHotel = AddTestFloorsAndRooms(tempHotel);
            Db.Hotels.Add(tempHotel);
            Db.SaveChanges();
        }
        public static Hotel AddTestFloorsAndRooms(Hotel tempHotel)
        {
            var db = new HotelLeSequelleContext();
            //var hotel = db.Hotels.Where(h => h.Name == tempHotel.Name).FirstOrDefault();
            Console.WriteLine("How many floors does your hotel have?");
            int NumberOfFloors = UniversalMethods.TryParseReadLine();
            UniversalMethods.ClearAboveCursor(1);
            for (int i = 1; i <= NumberOfFloors; i++)
            {
                var tempFloor = new Floor();
                tempFloor.FloorNumber = i;
                tempFloor.Hotel = tempHotel;
                Console.WriteLine($"How many rooms does floor {i} have?");
                int rooms = UniversalMethods.TryParseReadLine();
                for (int j = 1; j <= rooms; j++)
                {
                    var tempRoom = new Room();
                    if (j < 10)
                    {
                        tempRoom.RoomNumber = (i < 10) ? int.Parse("0" + (i) + "0" + (j + 1)) : int.Parse((i) + "0" + (j + 1));
                    }

                    else
                    {
                        tempRoom.RoomNumber = (i < 10) ? int.Parse("0" + (i) + (j + 1)) : ((i) + (j + 1));
                    }
                    tempRoom.Floor = tempFloor;
                    tempFloor.Rooms.Add(tempRoom);
                }

                tempHotel.Floors.Add(tempFloor);
            }

            tempHotel.NumberOfFloors = tempHotel.Floors.Count;
            int roomCount = 0;
            foreach (var floor in tempHotel.Floors)
            {
                roomCount += floor.Rooms.Count;
            }
            tempHotel.NumberOfRooms = roomCount;
            return tempHotel;

        }

        // Base
        public static int PrintMenu(List<Action> menuList, string menuName)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.BufferWidth / 2, 3);
            Console.WriteLine(menuName);
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            for (int i = 0; i < menuList.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {menuList[i].Method.Name}");
            }
            Console.WriteLine("[0]. Exit");
            int choise = TryParseReadLine(0, menuList.Count);
            return choise;
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
                        UniversalMethods.LoggedInUser = customer;
                        UniversalMethods.LoggedInUser.Run();
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
                    var receptionist = db.Receptionists.FirstOrDefault(s => s.UserName == userName && s.Password == password);
                    if (receptionist != null)
                    {
                        UniversalMethods.LoggedInUser = receptionist;
                        UniversalMethods.LoggedInUser.Run();
                    }
                    else
                    {
                        var waiter = db.Waiters.FirstOrDefault(w => w.UserName == userName && w.Password == password);
                        UniversalMethods.LoggedInUser = waiter;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR LOG IN STAFF");
                    Thread.Sleep(1500);
                }
            }
            if (UniversalMethods.LoggedInUser == null)
            {
                Console.WriteLine("Incorrect username or password, returning to menu");
                Thread.Sleep(2000);
                ClearAboveCursor(5);
            }
            else
            {
                UniversalMethods.LoggedInUser.Run();
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
                    var admin = db.Administrators.SingleOrDefault(a => a.Name == userName && a.Password == password);
                    if (admin != null)
                    {
                        UniversalMethods.LoggedInAdmin = admin;
                        UniversalMethods.LoggedInAdmin.Run();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect username or password");
                    Thread.Sleep(1500);
                    ClearAboveCursor(1);
                }
            }
        }
        public static void RunDev()
        {
            int choise;
            bool loop = true;
            while (loop)
            {
                choise = PrintMenu(DevMenu, "Developer Menu");
                if (choise == 0)
                {
                    loop = false;
                    break;
                }
                else
                {
                    DevMenu[choise - 1]();
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
                var availableRooms = db.Rooms.Where(r => r.Reservations.All(res => res.CheckInDate > checkOutDate && res.CheckOutDate < checkInDate)).ToList();
                if (availableRooms != null)
                {
                    foreach (var room in availableRooms)
                    {
                        Console.WriteLine($"{room.RoomNumber} is available between {checkInDate} and {checkOutDate}");
                    }
                    Console.WriteLine("Would you like to make a reservation? [Y/N]");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "y")
                    {
                        if (UniversalMethods.LoggedInUser is Customer)
                        {
                            (UniversalMethods.LoggedInUser as Customer).MakeReservation();
                        }
                        else
                        {
                            Console.WriteLine("You need to be logged in as a customer to make a reservation");
                            LogInCustomer();
                            (UniversalMethods.LoggedInUser as Customer).MakeReservation();
                        }
                    }
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
        public static void Run()
        {
            int choise;
            bool loop = true;
            while (loop)
            {
                choise = PrintMenu(BaseMenu, "Main Menu");
                if (choise == 0)
                {
                    loop = false;
                }
                else
                {
                    BaseMenu[choise - 1]();
                }
            }
        }
    }
}

