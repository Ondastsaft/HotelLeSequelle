namespace HotelLeSequelle.Models
{
    public partial class Customer : Person
    {
        public virtual ICollection<Reservation> Reservations { get; set; }
        public string CardDetails { get; set; }
        public Customer()
        {
            Reservations = new List<Reservation>();
        }
    }
}