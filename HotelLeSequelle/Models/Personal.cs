namespace HotelLeSequelle.Models
{
    public partial class Personal : Person
    {
        public int Anställningsdatum { get; set; }
        public int Anställningsnummer { get; set; }
        public string? Lösenord { get; set; }
        public virtual ICollection<Tilläggsbeställning> Tilläggsbeställningar { get; set; }
        public Personal()
        {
            Tilläggsbeställningar = new HashSet<Tilläggsbeställning>();
        }


    }
}

//public Personal(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
//    string epost, int anställningsdatum, int anställningsnummer, string lösenord, string roll) :
//    base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost)

//{
//    Anställningsdatum = anställningsdatum;
//    Anställningsnummer = anställningsnummer;
//    Lösenord = lösenord;
//    Tilläggsbestälningar = new HashSet<Tilläggsbeställning>();
//}