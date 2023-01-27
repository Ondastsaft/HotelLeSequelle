namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Staff
    {
        public int ReceptionistId { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public Receptionist()
        {
            Reservations = new List<Reservation>();
        }
    }

}
