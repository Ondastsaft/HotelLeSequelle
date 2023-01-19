namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Staff
    {
        public int ReceptionistID { get; set; }
        public virtual List<Reservation> Reservations { get; set; }

    }

}
