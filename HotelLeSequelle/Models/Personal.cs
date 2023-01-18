namespace HotelLeSequelle.Models
{
    public partial class Staff : Person
    {
        public DateTime DateOfEmployment { get; set; }
        public int EmployeeNumber { get; set; }
        public virtual ICollection<SideOrder> SideOrders { get; set; }
        public Staff()
        {
            SideOrders = new HashSet<SideOrder>();
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