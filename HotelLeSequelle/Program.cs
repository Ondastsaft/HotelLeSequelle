using HotelLeSequelle.Models;

namespace HotelLeSequelle
{
    public class Program
    {
        public static Person LoggedInUser { get; set; }
        public static Administrator? LoggedInAdmin { get; set; }
        static void Main(string[] args)
        {
            UniversalMethods.Run();
        }
    }
}



