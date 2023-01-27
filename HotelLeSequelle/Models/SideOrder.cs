namespace HotelLeSequelle.Models
{
    public class SideOrder
    {
        public int SideOrderId { get; set; }
        public List<SideOrderProduct> SideOrderProducts { get; set; }
        public Staff? Staff { get; set; }
        public Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
        public int OrderTotal { get; set; }
        public SideOrder()
        {
            SideOrderProducts = new List<SideOrderProduct>();
            Reservation = new Reservation();
        }

    }
}
