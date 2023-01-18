using HotelLeSequelle.Models;

namespace HotelLeSequelle
{
    //Ändra format på datetime (MM/DD/YYYY)
    public class Program
    {
        public static Person? LoggedInUser { get; set; }
        public static Administrator? LoggedInAdmin { get; set; }
        static void Main(string[] args)
        {
            //LoggedInAdmin = new Administrator();
            //LoggedInAdmin.Menu();
            //UniversalMethods.DeleteAllTables();
            //UniversalMethods.AddTestPersons();

        }
    }
}