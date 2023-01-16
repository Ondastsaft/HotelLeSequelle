namespace HotelLeSequelle.Models
{
    public partial class Våning
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public virtual Hotell Hotell { get; set; }
        public int HotellId { get; set; }
        public ICollection<Rum> Rum { get; set; }

        public Våning()
        {
            Rum = new HashSet<Rum>();
        }
    }
}
