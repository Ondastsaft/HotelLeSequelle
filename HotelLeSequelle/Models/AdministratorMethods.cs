namespace HotelLeSequelle.Models
{
    public partial class Administrator
    {

        public void Run()
        {
            List<Action> MenuList = new List<Action>();
            MenuList = AddMethodsToMenuList(MenuList);
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the {this.GetType().Name} Menu");
                Console.WriteLine("Please select an option:");
                for (int i = 0; i < MenuList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {MenuList[i].Method.Name}");
                }
                Console.WriteLine("0. Exit");
                Console.Write("Selection: ");
                int selection = UniversalMethods.TryParseReadLine();
                if (selection == 0)
                {
                    break;
                }
                else
                {
                    MenuList[selection - 1]();
                }
            }
        }

        public List<Action> AddMethodsToMenuList(List<Action> menuList)
        {
            Type thisType = this.GetType();
            var methodinfo = thisType.GetType().GetMethods();
            foreach (var method in methodinfo)
            {
                method.CreateDelegate(typeof(Action), menuList);
            }
            return menuList;
        }
        private void AddHotel()
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
            //Console.WriteLine("Name your new Hotel");
            //tempHotel.Name = Console.ReadLine(); Console.Clear();
            //Console.WriteLine("Name the adress of your new Hotel");
            //tempHotel.StreetAdress = Console.ReadLine(); Console.Clear();
            //Console.WriteLine("Enter the phone number of your new hotel");
            //tempHotel.PhoneNumber = Console.ReadLine(); Console.Clear();
            //Console.WriteLine("In which country is the hotel resided");
            //tempHotel.Country = Console.ReadLine(); Console.Clear();
            //Console.WriteLine("Enter zip code for your new hotel");
            //tempHotel.ZipCode = Console.ReadLine(); Console.Clear();
            //Console.WriteLine("Enter locality for your new hotel");
            //tempHotel.Locality = Console.ReadLine(); Console.Clear();
            //Console.WriteLine("Enter main contact E-mail for your hotel");
            //tempHotel.Email = Console.ReadLine(); Console.Clear();
            //Console.WriteLine("Enter the webpage of your new hotel");
            //tempHotel.WebPage = Console.ReadLine(); Console.Clear();          
            tempHotel = AddFloorsAndRooms(tempHotel);
            var Db = new HotelLeSequelleContext();
            Db.Hotels.Add(tempHotel);
            Db.SaveChanges();
        }
        private Hotel AddFloorsAndRooms(Hotel tempHotel)
        {
            Console.WriteLine("How many floors does your hotel have?");
            tempHotel.NumberOfFloors = UniversalMethods.TryParseReadLine();
            UniversalMethods.ClearAboveCursor(1);
            for (int i = 1; i <= tempHotel.NumberOfFloors; i++)
            {
                var tempFloor = new Floor();
                tempFloor.FloorNumber = i;
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
        private void PrintAllReservations()
        {
            var Db = new HotelLeSequelleContext();
            var reservations = Db.Reservations.ToList();
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"" +
                    $"Reservation ID: {reservation.ReservationId} " +
                    $"Customer: {reservation.Customer.FirstName} {reservation.Customer.LastName} " +
                    $"Room: {reservation.Room.RoomNumber} " +
                    $"Check in: {reservation.CheckInDate} " +
                    $"Check out: {reservation.CheckOutDate})");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
