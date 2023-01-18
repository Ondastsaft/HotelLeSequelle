namespace HotelLeSequelle.Models
{
    public partial class Staff : Person
    {
        public DateTime DateOfEmployment { get; set; }
        public int EmployeeNumber { get; set; }
        public virtual ICollection<SideOrder> SideOrders { get; set; }
        public Staff()
        {
            SideOrders = new HashSet<SideOrder>();
        }
    }
}
