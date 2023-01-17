namespace HotelLeSequelle.Models
{
    public abstract partial class Person
    {
        public int Id { get; set; }
        public string SirName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string StreetAdress { get; set; }
        public string ZipCode { get; set; }
        public string Locality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}

//public Person(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer, string epost)
//{
//    Förnamn = förnamn;
//    Efternamn = efternamn;
//    Nationalitet = nationalitet;
//    Gatuadress = gatuadress;
//    Postnummer = postnummer;
//    Postort = postort;
//    Telefonnummer = telefonnummer;
//    Epost = epost;
//}
