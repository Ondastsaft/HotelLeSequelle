namespace HotelLeSequelle.Models
{
    public class SideOrder
    {
        public int Id { get; set; }
        public virtual List<SideOrderProduct> SideOrderProducts { get; set; }
        public Staff Staff { get; set; }
        public int StaffId { get; set; }
        public Reservation Reservation { get; set; }
        public int ReservationId { get; set; }
        public int OrderTotal { get; set; }

    }
}
