namespace HotelLeSequelle.Models
{
    public class Rum
    {
        public int Id { get; set; }
        public virtual Våning Våning { get; set; }
        public int VåningsId { get; set; }
        public virtual ICollection<Bokning> Boknings { get; set; }

        public Rum()
        {
            Boknings = new HashSet<Bokning>();
        }
    }
}
