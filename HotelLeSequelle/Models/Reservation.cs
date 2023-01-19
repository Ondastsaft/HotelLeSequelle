namespace HotelLeSequelle.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public virtual Receptionist? Receptionist { get; set; }
        public int? ReceptionistId { get; set; }
        public List<SideOrder> SideOrders { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Reservation()
        {
            SideOrders = new List<SideOrder>();
        }





    }
}
