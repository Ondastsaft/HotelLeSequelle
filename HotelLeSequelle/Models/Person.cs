namespace HotelLeSequelle.Models
{
    public abstract partial class Person
    {
        public int Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Nationalitet { get; set; }
        public string Gatuadress { get; set; }
        public string Postnummer { get; set; }
        public string Postort { get; set; }
        public string Telefonnummer { get; set; }
        public string Epost { get; set; }
        public Person(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer, string epost)
        {
            Förnamn = förnamn;
            Efternamn = efternamn;
            Nationalitet = nationalitet;
            Gatuadress = gatuadress;
            Postnummer = postnummer;
            Postort = postort;
            Telefonnummer = telefonnummer;
            Epost = epost;
        }

    }
}
