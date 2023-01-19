namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Staff
    {
        public virtual List<Reservation> Reservations { get; set; }

    }

}
