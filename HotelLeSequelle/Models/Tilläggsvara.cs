namespace HotelLeSequelle.Models
{
    public class Tilläggsvara
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int Pris { get; set; }
        public int Antal { get; set; }
        public virtual ICollection<Tilläggsbeställning> Tilläggsbeställning { get; set; }
        public Tilläggsvara()
        {
            Tilläggsbeställning = new HashSet<Tilläggsbeställning>();
        }
    }
}
