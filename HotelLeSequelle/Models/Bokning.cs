namespace HotelLeSequelle.Models
{
    public class Bokning
    {
        public int Id { get; set; }
        public virtual Hotell BokningensHotell { get; set; }
        public int HotellId { get; set; }
        public virtual Kund BokandeKund { get; set; }
        public int KundId { get; set; }
        public Rum BokatRum { get; set; }
        public int BokatRumId { get; set; }
        public virtual Personal BokandePersonal { get; set; }
        public int BokandePersonalId { get; set; }
        public virtual ICollection<Tilläggsbeställning> Tilläggsbeställningar { get; set; }
        public DateTime IncheckningsDatum { get; set; }
        public DateTime UtcheckningsDatum { get; set; }

        public Bokning()
        {
            Tilläggsbeställningar = new HashSet<Tilläggsbeställning>();
        }



    }
}
