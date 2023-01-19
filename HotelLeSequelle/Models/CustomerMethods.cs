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
            var availableRoom = db.Rooms.Where(r => r.Reservations.Any(res => res.CheckInDate <= reservation.CheckInDate && res.CheckOutDate >= reservation.CheckInDate)).FirstOrDefault();
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
