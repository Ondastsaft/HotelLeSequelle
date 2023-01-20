namespace HotelLeSequelle.Models
{
    public partial class Customer
    {
        public override void Run()
        {
            List<Action> MenuList = new List<Action>() { MakeReservation, ViewReservations, CheckInToRoom, CheckOutFromRoom, OrderSideOrder };

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
        public void CheckInToRoom()
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
            Console.WriteLine("Select a room to check in to or press 0 to exit");
            int choise = UniversalMethods.TryParseReadLine();
            if (choise != 0)
            {
                var reservation = reservations[choise - 1];
                reservation.CheckInDate = DateTime.Now;
                db.SaveChanges();
                Console.WriteLine();
                Console.WriteLine($"You have checked in to room number {reservation.Room.RoomNumber}");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
        }
        public void CheckOutFromRoom()
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
            Console.WriteLine("Select a room to check out from or press 0 to exit");
            int choise = UniversalMethods.TryParseReadLine();
            if (choise != 0)
            {
                var reservation = reservations[choise - 1];
                reservation.CheckOutDate = DateTime.Now;
                db.SaveChanges();
                Console.WriteLine();
                Console.WriteLine($"You have checked out from room number {reservation.Room.RoomNumber}");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
        }
        public void OrderSideOrder()
        {
            var db = new HotelLeSequelleContext();
            var customer = db.Customers.FirstOrDefault(c => c.CustomerId == this.CustomerId);
            var reservation = db.Reservations.Where(r => r.CustomerId == customer.CustomerId && DateTime.Now > r.CheckInDate && DateTime.Now < r.CheckOutDate).FirstOrDefault();
            if (reservation != null)
            {
                var products = db.Products.ToList();
                Console.WriteLine("Welcome to order room service:");
                bool order = true;
                SideOrder sideOrder = new SideOrder();
                sideOrder.ReservationId = reservation.ReservationId;
                Dictionary<int, int> produktidamount = new Dictionary<int, int>();
                while (order)
                {
                    int i = 1;
                    Console.Clear();
                    foreach (var product in products)
                    {
                        Console.WriteLine($"[{i}] {product.Name} - {product.Price}$");
                        i++;
                    }
                    Console.WriteLine("What would you like to order? (press 0 to exit)");
                    int productIndex = UniversalMethods.TryParseReadLine();
                    if (productIndex != 0)
                    {

                        Console.WriteLine($"How many {products[productIndex - 1].Name} would you like to order?");
                        int orderedAmount = UniversalMethods.TryParseReadLine();
                        produktidamount.Add(productIndex, orderedAmount);


                        foreach (var kvp in produktidamount)
                        {
                            Console.WriteLine($"You have ordered {kvp.Value} {products[kvp.Key - 1].Name}");
                        }

                        Console.WriteLine("Would you like to order anything else? (y/n)");
                        var orderMore = Console.ReadLine();
                        order = orderMore == "y";
                    }
                }
                Console.WriteLine("Thank you for your order");
                db.SideOrders.Add(sideOrder);
                foreach (var kvp in produktidamount)
                {
                    var product = db.Products.FirstOrDefault(p => p.ProductId == kvp.Key);
                    var sideOrderProduct = new SideOrderProduct();
                    sideOrderProduct.ProductId = product.ProductId;
                    sideOrderProduct.SideOrderId = db.Reservations.Where(r => r.ReservationId == reservation.ReservationId).FirstOrDefault().SideOrders.LastOrDefault().SideOrderId;
                    sideOrderProduct.Amount = kvp.Value;
                    db.SideOrderProducts.Add(sideOrderProduct);
                }
                db.SaveChanges();
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You are not checked in to any room");
                Console.WriteLine("Press any key to return to menu");
                Console.ReadKey();
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
