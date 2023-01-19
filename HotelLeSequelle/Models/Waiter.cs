namespace HotelLeSequelle.Models
{
    public partial class Waiter : Staff
    {
        public virtual ICollection<SideOrder> SideOrders { get; set; }
        public Waiter()
        {
            SideOrders = new HashSet<SideOrder>();

        }

    }
}
