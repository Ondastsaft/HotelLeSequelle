namespace HotelLeSequelle.Models
{
    public abstract class Staff : Person
    {
        public int StaffId { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public int? EmployeeNumber { get; set; }
        public virtual List<SideOrder>? SideOrders { get; set; }

        public override void Run()
        {

        }
        public override List<Action> AddMethodsToMenuList(List<Action> menuList)
        {
            return menuList;
        }

    }
}
