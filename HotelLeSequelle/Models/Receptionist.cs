namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Personal
    {
        public ICollection<Bokning> Bokningar { get; set; }
        public ICollection<Tilläggsbeställning> Tilläggsbeställningar { get; set; }

        public Receptionist(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
            string epost, int anställningsdatum, int anställningsnummer, string lösenord, string roll) :
            base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost, anställningsdatum, anställningsnummer, lösenord, roll)
        {
            Bokningar = new HashSet<Bokning>();
            Tilläggsbeställningar = new HashSet<Tilläggsbeställning>();
        }
    }
}
