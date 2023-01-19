namespace HotelLeSequelle.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public virtual List<SideOrder> SideOrders { get; set; }
    }
}
