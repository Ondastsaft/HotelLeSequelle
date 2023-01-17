namespace HotelLeSequelle.Models
{
    public class SideOrder
    {
        public int Id { get; set; }
        public ICollection<SideOrderProduct> SideOrderProducts { get; set; }
        public virtual Staff Staff { get; set; }
        public int StaffId { get; set; }
        public virtual Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
        public int OrderTotal { get; set; }
        public SideOrder()
        {
            SideOrderProducts = new HashSet<SideOrderProduct>();
        }
    }
}
