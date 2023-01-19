namespace HotelLeSequelle.Models
{
    public partial class Staff : Person
    {
        public int StaffId { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int EmployeeNumber { get; set; }
        public virtual List<SideOrder> SideOrders { get; set; }
        public Staff()
        {
            SideOrders = new List<SideOrder>();
        }

    }
}
