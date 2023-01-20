namespace HotelLeSequelle.Models
{
    public class SideOrderProduct
    {
        public int SideOrderProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public virtual SideOrder SideOrder { get; set; }
        public int SideOrderId { get; set; }

    }
}
