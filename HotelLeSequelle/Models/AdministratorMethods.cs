namespace HotelLeSequelle.Models
{
    public partial class Administrator
    {
        //Lägga till våningar och rum Vid Skapande av Hotellet
        public void Menu()
        {
            List<Action> methods = new List<Action>() { AddHotel };

            Console.WriteLine("Choose option");
            for (int i = 0; i < methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {methods[i].Method.Name}");
            }
            Console.WriteLine("0. Exit");
            int key = UniversalMethods.TryParseReadKey(1, methods.Count());
            methods[key - 1].Invoke();
        }
        private void AddHotel()
        {
            Hotel tempHotel = new Hotel();
            Console.Clear();
            Console.WriteLine("Name your new Hotel");
            tempHotel.Name = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Name the adress of your new Hotel");
            tempHotel.StreetAdress = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Enter the phone number of your new hotel");
            tempHotel.PhoneNumber = Console.ReadLine(); Console.Clear();
            Console.WriteLine("In which country is the hotel");
            tempHotel.Country = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Enter zip code for your new hotel");
            tempHotel.ZipCode = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Enter locality for your new hotel");
            tempHotel.Locality = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Enter main contact E-mail for your hotel");
            tempHotel.Email = Console.ReadLine(); Console.Clear();
            Console.WriteLine("Enter the webpage of your new hotel");
            tempHotel.WebPage = Console.ReadLine(); Console.Clear();
            var Db = new HotelLeSequelleContext();
            Db.Hotell.Add(tempHotel);
            Db.SaveChanges();
            AddFloorsAndRooms(tempHotel.Name);
        }
        private void AddFloorsAndRooms(string hotelname)
        {
            Console.WriteLine("How many floors does your hotel have?");
            int floors = UniversalMethods.TryParseReadKey();
            UniversalMethods.ClearAboveCursor(2);
            var db = new HotelLeSequelleContext();
            var hotel = db.Hotell.Where(h => h.Name == hotelname).SingleOrDefault();
            for (int i = 0; i < floors; i++)
            {
                var tempFloor = new Floor();
                tempFloor.FloorNumber = i + 1;
                try
                {
                    tempFloor.HotelId = hotel.ID;
                }
                catch
                {
                    Console.WriteLine("Error retrieving hotel from database");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine($"How many rooms does floor {i + 1} have?");
                int rooms = UniversalMethods.TryParseReadLine();
                for (int j = 0; j < rooms; j++)
                {
                    var tempRoom = new Room();
                    if (j < 10)
                    {
                        tempRoom.RoomNumber = (i < 10) ? int.Parse("0" + (i + 1) + "0" + (j + 1)) : int.Parse((i + 1) + "0" + (j + 1));
                    }
                    else
                    {
                        tempRoom.RoomNumber = (i < 10) ? int.Parse("0" + (i + 1) + (j + 1)) : ((i + 1) + (j + 1));
                    }
                    tempRoom.Floor = tempFloor;
                    tempFloor.Rooms.Add(tempRoom);
                    db.Add(tempFloor);
                }

            }
        }
    }
}
