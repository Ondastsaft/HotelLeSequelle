namespace HotelLeSequelle.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? Stock { get; set; }
        public virtual ICollection<SideOrder> SideOrders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public Product()
        {
            SideOrders = new HashSet<SideOrder>();
            Reservations = new HashSet<Reservation>();
        }

    }
}
