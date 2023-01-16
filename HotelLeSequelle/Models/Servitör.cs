namespace HotelLeSequelle.Models
{
    public partial class Servitör : Person
    {
        public virtual ICollection<Tilläggsbeställning> MottagnaTilläggsbeställningar { get; set; }

        public Servitör(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
            string epost) : base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost)
        {
            MottagnaTilläggsbeställningar = new HashSet<Tilläggsbeställning>();
        }

    }
}
