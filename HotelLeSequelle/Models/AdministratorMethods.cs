namespace HotelLeSequelle.Models
{
    public partial class Administrator
    {
        public List<Action> MenuList = new List<Action>();
        public void Menu()
        {
            List<Action> methods = new List<Action>() { AddHotel };

            Console.WriteLine("Choose option");
            for (int i = 0; i < methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {methods[i].Method.Name}");
            }
            Console.WriteLine("0. Exit");
            int key = UniversalMethods.TryParseReadKey(1, methods.Count);
            methods[key - 1].Invoke();
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
    }
}
