namespace HotelLeSequelle.Models
{
    public abstract partial class Personal : Person
    {
        public int Anställningsdatum { get; set; }
        public int Anställningsnummer { get; set; }
        public string? Lösenord { get; set; }
        public string? Roll { get; set; }
        public Personal(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
            string epost, int anställningsdatum, int anställningsnummer, string lösenord, string roll) :
            base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost)
        {
            Anställningsdatum = anställningsdatum;
            Anställningsnummer = anställningsnummer;
            Lösenord = lösenord;
            Roll = roll;
        }

    }
}

