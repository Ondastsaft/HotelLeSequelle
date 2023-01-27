using System.Diagnostics.CodeAnalysis;

namespace HotelLeSequelle.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        [AllowNull]
        public Receptionist Receptionist { get; set; }
        [AllowNull]
        public List<SideOrder> SideOrders { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Reservation()
        {
            Customer = new Customer();
            Room = new Room();
        }
    }
}
