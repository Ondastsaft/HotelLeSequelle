namespace HotelLeSequelle.Models
{
    public abstract class Staff : Person
    {
        public DateTime? DateOfEmployment { get; set; }
        public int? EmployeeNumber { get; set; }
        public virtual List<SideOrder>? SideOrders { get; set; }
    }
}
