namespace HotelLeSequelle.Models
{
    public partial class Customer
    {
        public override void Run()
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
                int selection = int.Parse(Console.ReadLine());
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
        public override List<Action> AddMethodsToMenuList(List<Action> menuList)
        {
            menuList.Add(MakeReservation);
            menuList.Add(ViewReservations);
            return menuList;
        }
        public void MakeReservation()
        {
            var reservation = new Reservation();
            Console.WriteLine("From which date do you want to stay with us? (dd/mm/yyyy)");
            reservation.CheckInDate = UniversalMethods.TryParseDateTime();
            Console.WriteLine("When will you be leaving? (dd/mm/yyyy)");
            reservation.CheckOutDate = UniversalMethods.TryParseDateTime();
            var db = new HotelLeSequelleContext();
            var reservations = db.Reservations.ToList();
            var rooms = db.Rooms.ToList();
            foreach (var room in rooms)
            {
                foreach (var res in reservations)
                {
                    if (room.RoomId == res.RoomId)
                    {
                        if (reservation.CheckInDate >= res.CheckInDate && reservation.CheckInDate <= res.CheckOutDate)
                        {
                            rooms.Remove(room);
                        }
                        else if (reservation.CheckOutDate >= res.CheckInDate && reservation.CheckOutDate <= res.CheckOutDate)
                        {
                            rooms.Remove(room);
                        }
                    }
                }
            }
            Console.WriteLine("Here are the rooms available for your stay:");
            int i = 1;
            foreach (var room in rooms)
            {
                var floor = db.Floors.FirstOrDefault(f => f.FloorId == room.FloorId);
                Console.WriteLine($"[{i}] Room number {room.RoomNumber} on floor {floor.FloorNumber}");
                i++;
            }

            Console.WriteLine("Select a room to make a reservation or press 0 to exit");
            int choise = UniversalMethods.TryParseReadLine();
            if (choise != 0)
            {
                var customer = db.Customers.FirstOrDefault(c => c.CustomerId == this.CustomerId);
                reservation.Room = rooms[choise - 1];
                reservation.Customer = (customer);
                db.Reservations.Add(reservation);
                db.SaveChanges();
                Console.WriteLine();
                Console.WriteLine($"{reservation.Room.RoomNumber} booked for {reservation.Customer.SirName} {reservation.Customer.LastName} between {reservation.CheckInDate} and {reservation.CheckOutDate}");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }


        }
        public void ViewReservations()
        {
            var db = new HotelLeSequelleContext();
            var customer = db.Customers.FirstOrDefault(c => c.CustomerId == this.CustomerId);
            var reservations = db.Reservations.Where(r => r.CustomerId == customer.CustomerId).ToList();
            Console.WriteLine("Here are your reservations:");
            foreach (var reservation in reservations)
            {
                var room = db.Rooms.FirstOrDefault(r => r.RoomId == reservation.RoomId);
                Console.WriteLine($"Room number {room.RoomNumber} between {reservation.CheckInDate} and {reservation.CheckOutDate}");

            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey();
        }
        public void OrderRoomService()
        {

        }
        public void MakeReservation(DateTime checkInDate, DateTime checkOutDate)
        {
            var reservation = new Reservation();
            var db = new HotelLeSequelleContext();
            var availableRoom = db.Rooms.Where(r => r.Reservations.Any(res => checkInDate <= reservation.CheckInDate && checkOutDate >= reservation.CheckInDate)).FirstOrDefault();
            if (availableRoom != null)
            {
                Console.WriteLine($"Room {availableRoom.RoomNumber} is available from {reservation.CheckInDate} to {reservation.CheckOutDate}");
                Console.WriteLine("Do you want to book this room? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    reservation.Room = availableRoom;
                    reservation.Customer = this;
                    db.Reservations.Add(reservation);
                    db.SaveChanges();
                    Console.WriteLine("Reservation made!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }

        }
    }
}
