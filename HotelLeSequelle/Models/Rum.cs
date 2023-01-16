namespace HotelLeSequelle.Models
{
    public class Rum
    {
        public int Id { get; set; }
        public virtual Våning RummetsVåning { get; set; }
        public int VåningsId { get; set; }
        public virtual ICollection<Bokning> RummetsBokningar { get; set; }

    }
}
