namespace HotelLeSequelle.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public virtual List<SideOrderProduct> SideOrderProducts { get; set; }
        public Product()
        {
            SideOrderProducts = new List<SideOrderProduct>();
            Name = "NOT YET PROVIDED";
        }
    }
}
