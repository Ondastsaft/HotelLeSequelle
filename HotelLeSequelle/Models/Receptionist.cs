namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Staff
    {
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<SideOrder> SideOrders { get; set; }

        public Receptionist()
        {
            Reservations = new HashSet<Reservation>();
            SideOrders = new HashSet<SideOrder>();
        }
    }
}

//public Receptionist(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
//    string epost, int anställningsdatum, int anställningsnummer, string lösenord, string roll) :
//    base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost, anställningsdatum, anställningsnummer, lösenord, roll)