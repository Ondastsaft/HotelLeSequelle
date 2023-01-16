namespace HotelLeSequelle.Models
{
    public partial class Våning
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public virtual Hotell Hotell { get; set; }
        public int HotellId { get; set; }
        public ICollection<Rum> VåningensRum { get; set; }

        public Våning()
        {
            VåningensRum = new HashSet<Rum>();
        }
    }
}
