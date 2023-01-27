namespace HotelLeSequelle.Models
{
    public class Hotel
    {
        public int HoteliD { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public virtual ICollection<Floor> Floors { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string StreetAdress { get; set; }
        public string ZipCode { get; set; }
        public string Locality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebPage { get; set; }
        public Hotel()
        {
            Floors = new List<Floor>();
            Name = "NOT YET PROVIDED";
            Country = "NOT YET PROVIDED";
            StreetAdress = "NOT YET PROVIDED";
            ZipCode = "NOT YET PROVIDED";
            Locality = "NOT YET PROVIDED";
            PhoneNumber = "NOT YET PROVIDED";
            Email = "NOT YET PROVIDED";
            WebPage = "NOT YET PROVIDED";
        }

    }
}
