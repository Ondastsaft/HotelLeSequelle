namespace HotelLeSequelle.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Customer ReservationCustomer { get; set; }
        public int ReservationCustomerID { get; set; }
        public Room ReservationRoom { get; set; }
        public int ReservationRoomId { get; set; }
        public Receptionist? ReservationReceptionist { get; set; }
        public int? ReservationReceptionistId { get; set; }
        public List<SideOrder> ReservationSideOrders { get; set; }
        public bool PaidAndClosed { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public Reservation()
        {
            ReservationSideOrders = new List<SideOrder>();
        }
    }
}
