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

//    public Kund(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
//string epost) : base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost)
//    {
//        Bokningar = new HashSet<Bokning>();
//    }
