using HotelLeSequelle.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelLeSequelle
{
    public static class Developer
    {
        public static void Run()
        {
            List<Action> DevMenu = new List<Action>()
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
            int choise;
            bool loop = true;
            while (loop)
            {
                choise = Base.PrintMenu(DevMenu, "Developer Menu");
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
            //int roomNumber = UniversalMethods.TryParseReadLine();
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
                    Console.WriteLine("No Customers in database");
                    Thread.Sleep(1500);
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
                            UniversalMethods.PrintInMiddle("No waiter in database");
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
                        UniversalMethods.PrintInMiddle("ERROR LOG IN TEST RECEPTIONIST");
                        Thread.Sleep(500);
                        Console.Clear();
                        Thread.Sleep(500);
                    }
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
                            UniversalMethods.PrintInMiddle("No waiter in database");
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
                        UniversalMethods.PrintInMiddle("ERROR LOG IN TEST RECEPTIONIST");
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
                            UniversalMethods.PrintInMiddle("No waiter in database");
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
                        UniversalMethods.PrintInMiddle("ERROR LOG IN TEST Waiter");
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
    }
}
