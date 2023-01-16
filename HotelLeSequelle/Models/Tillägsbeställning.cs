namespace HotelLeSequelle.Models
{
    public class Tilläggsbeställning
    {
        public int Id { get; set; }
        public ICollection<Tilläggsvara> Tilläggsvaror { get; set; }
        public Personal Säljare { get; set; }
        public int SäljarId { get; set; }
        public Bokning Bokning { get; set; }
        public int BokningsId { get; set; }
        public int OrderTotal { get; set; }
        public Tilläggsbeställning(HashSet<Tilläggsvara> beställning)
        {
            Tilläggsvaror = beställning;
            OrderTotal = SummeraVaror();
        }
        public int SummeraVaror()
        {
            int summa = 0;
            foreach (Tilläggsvara vara in Tilläggsvaror)
            {
                summa += vara.Pris;
            }
            return summa;
        }
        public Tilläggsbeställning()
        {
            Tilläggsvaror = new HashSet<Tilläggsvara>();
        }
    }
}
