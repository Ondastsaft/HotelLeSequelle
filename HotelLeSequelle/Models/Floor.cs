namespace HotelLeSequelle.Models
{
    public partial class Floor
    {
        public int FloorId { get; set; }
        public int FloorNumber { get; set; }
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public Floor()
        {
            Rooms = new HashSet<Room>();
        }
    }


}
