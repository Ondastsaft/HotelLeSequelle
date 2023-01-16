namespace HotelLeSequelle.Models
{
    public class Tilläggsbeställning
    {
        public int Id { get; set; }
        public ICollection<Tilläggsvara> Tilläggsvaror { get; set; }
        public virtual Personal Personal { get; set; }
        public int PersonalId { get; set; }
        public virtual Bokning Bokning { get; set; }
        public int BokningsId { get; set; }
        public int OrderTotal { get; set; }
        public Tilläggsbeställning()
        {
            Tilläggsvaror = new HashSet<Tilläggsvara>();
        }
    }
}
