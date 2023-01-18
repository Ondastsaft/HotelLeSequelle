namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Staff
    {
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<SideOrder> SideOrders { get; set; }
        public Receptionist()
        {
            Reservations = new HashSet<Reservation>();
            SideOrders = new HashSet<SideOrder>();
        }
    }
}
