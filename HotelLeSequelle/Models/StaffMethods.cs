namespace HotelLeSequelle.Models
{
    public partial class Staff : Person
    {
        public override void Run()
        {
            List<Action> MenuList = new List<Action>();
            MenuList = AddMethodsToMenuList(MenuList);
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the {this.GetType().Name} Menu");
                Console.WriteLine("Please select an option:");
                for (int i = 0; i < MenuList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {MenuList[i].Method.Name}");
                }
                Console.WriteLine("0. Exit");
                Console.Write("Selection: ");
                int selection = int.Parse(Console.ReadLine());
                if (selection == 0)
                {
                    break;
                }
                else
                {
                    MenuList[selection - 1]();
                }
            }
        }
        public override List<Action> AddMethodsToMenuList(List<Action> menuList)
        {

            return menuList;
        }
    }
}
