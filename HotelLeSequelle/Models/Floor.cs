namespace HotelLeSequelle.Models
{
    public partial class Floor
    {
        public int Id { get; set; }
        public int FloorNumber { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        public ICollection<Room> Rooms { get; set; }

        public Floor()
        {
            Rooms = new HashSet<Room>();
        }
    }
}
