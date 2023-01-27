namespace HotelLeSequelle.Models
{
    public partial class Customer : Person
    {
        public int CustomerId { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public string? CardDetails { get; set; }
        public Customer()
        {
            Reservations = new List<Reservation>();
        }
    }
}