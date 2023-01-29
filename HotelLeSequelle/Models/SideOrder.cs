namespace HotelLeSequelle.Models
{
    public class SideOrder
    {
        public int SideOrderId { get; set; }
        public List<SideOrderProduct> SideOrderProducts { get; set; }
        public Receptionist? SideOrderReceptionist { get; set; }
        public Waiter? SideOrderWaiter { get; set; }
        public Reservation? SideOrderReservation { get; set; }
        public int OrderTotal { get; set; }
        public SideOrder()
        {
            SideOrderProducts = new List<SideOrderProduct>();
        }

    }
}
