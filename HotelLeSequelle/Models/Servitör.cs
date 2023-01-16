namespace HotelLeSequelle.Models
{
    public partial class Servitör : Personal
    {


        //public Servitör(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
        //    string epost, int anställningsdatum, int anställningsnummer, string lösenord, string roll) :
        //    base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost, anställningsdatum, anställningsnummer, lösenord, roll)
        public virtual ICollection<Tilläggsbeställning> Tilläggsbeställnings { get; set; }
        public int TilläggsbeställningsId { get; set; }
        public Servitör()
        {
            Tilläggsbeställnings = new HashSet<Tilläggsbeställning>();
        }

    }
}
