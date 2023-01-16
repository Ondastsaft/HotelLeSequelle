namespace HotelLeSequelle.Models
{
    public class Tilläggsvara
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int Pris { get; set; }
        public virtual ICollection<Tilläggsbeställning> Tilläggsbeställningar { get; set; }
        public Tilläggsvara()
        {
            Tilläggsbeställningar = new HashSet<Tilläggsbeställning>();
        }
    }
}
