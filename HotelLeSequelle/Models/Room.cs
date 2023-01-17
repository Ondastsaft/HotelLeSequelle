namespace HotelLeSequelle.Models
{
    public class Room
    {
        public int Id { get; set; }
        public virtual Floor Floor { get; set; }
        public int RoomNumber { get; set; }
        public int FloorId { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }
    }
}
