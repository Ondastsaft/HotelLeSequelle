namespace HotelLeSequelle.Models
{
    public partial class Waiter : Staff
    {


        //public Servitör(string förnamn, string efternamn, string nationalitet, string gatuadress, string postnummer, string postort, string telefonnummer,
        //    string epost, int anställningsdatum, int anställningsnummer, string lösenord, string roll) :
        //    base(förnamn, efternamn, nationalitet, gatuadress, postnummer, postort, telefonnummer, epost, anställningsdatum, anställningsnummer, lösenord, roll)
        public virtual ICollection<SideOrder> SideOrders { get; set; }

        public Waiter()
        {
            SideOrders = new HashSet<SideOrder>();
        }

    }
}
