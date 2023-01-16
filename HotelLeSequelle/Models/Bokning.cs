namespace HotelLeSequelle.Models
{
    public class Bokning
    {
        public int Id { get; set; }
        public virtual Kund Kund { get; set; }
        public int KundId { get; set; }
        public Rum Rum { get; set; }
        public int RumId { get; set; }
        public virtual Receptionist Receptionist { get; set; }
        public int ReceptionistId { get; set; }
        public virtual ICollection<Tilläggsbeställning> Tilläggsbeställnings { get; set; }
        public DateTime IncheckningsDatum { get; set; }
        public DateTime UtcheckningsDatum { get; set; }

        public Bokning()
        {
            Tilläggsbeställnings = new HashSet<Tilläggsbeställning>();
        }



    }
}
