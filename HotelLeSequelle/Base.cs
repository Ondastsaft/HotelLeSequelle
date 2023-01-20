using HotelLeSequelle.Models;

namespace HotelLeSequelle
{
    public static class Base
    {
        public static Customer LoggedInCustomer { get; set; }
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
            int choise = UniversalMethods.TryParseReadLine(0, menuList.Count);
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
                UniversalMethods.ClearAboveCursor(5);
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
                    UniversalMethods.ClearAboveCursor(1);
                }
            }
        }
        public static void RunDev()
        {
            Developer.Run();
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
            List<Action> BaseMenu = new List<Action>()
        {
            LogInCustomer,
            LogInStaff,
            LogInAdmin,
            RegisterNewCustomer,
            SearchAvailableRooms,
            RunDev
        };
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
