namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Staff
    {

        public override void Run()
        {
        }
        public override List<Action> AddMethodsToMenuList(List<Action> menuList)
        {
            return menuList;
        }


    }
}
