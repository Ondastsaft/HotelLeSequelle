namespace HotelLeSequelle.Models
{
    public class SideOrderProduct
    {
        public int SideOrderProductId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public SideOrder SideOrder { get; set; }
        public int SideOrderId { get; set; }
    }
}
