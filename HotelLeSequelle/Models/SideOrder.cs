namespace HotelLeSequelle.Models
{
    public class SideOrder
    {
        public int SideOrderId { get; set; }
        public List<SideOrderProduct> SideOrderProducts { get; set; }
        public Staff? SideOrderStaff { get; set; }
        public Reservation? SideOrderReservation { get; set; }
        public int? SideOrderReservationId { get; set; }
        public int OrderTotal { get; set; }
        public SideOrder()
        {
            SideOrderProducts = new List<SideOrderProduct>();
            SideOrderReservation = new Reservation();
        }

    }
}
