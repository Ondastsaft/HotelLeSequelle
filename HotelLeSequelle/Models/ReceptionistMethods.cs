namespace HotelLeSequelle.Models
{
    public partial class Receptionist : Staff
    {
        public override void Menu()
        {
            Console.Clear();
            Console.WriteLine("I am a receptionist");

        }
    }
}
