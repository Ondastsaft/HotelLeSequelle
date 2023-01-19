namespace HotelLeSequelle.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public Floor Floor { get; set; }
        public int FloorId { get; set; }
        public int RoomNumber { get; set; }
        public List<Reservation> Reservations { get; set; }
        public Room()
        {
            Reservations = new List<Reservation>();
        }
    }
}
