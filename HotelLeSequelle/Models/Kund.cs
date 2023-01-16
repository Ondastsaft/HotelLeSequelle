namespace HotelLeSequelle.Models
{
    public class Kund : Person
    {
        public virtual ICollection<Bokning> Boknings { get; set; }

        public string Kortuppgifter { get; set; }

        public Kund()
        {
            Boknings = new List<Bokning>();
        }


    }
}

//    public Kund(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
//string epost) : base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost)
//    {
//        Bokningar = new HashSet<Bokning>();
//    }
