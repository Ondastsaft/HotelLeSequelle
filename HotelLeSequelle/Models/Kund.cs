namespace HotelLeSequelle.Models
{
    public class Kund : Person
    {
        public virtual ICollection<Bokning> Bokningar { get; set; }

        public int Kortuppgifter { get; set; }

        public Kund(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
    string epost) : base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost)
        {
            Bokningar = new HashSet<Bokning>();
        }

    }
}
