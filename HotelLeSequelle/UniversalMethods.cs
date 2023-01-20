using HotelLeSequelle.Models;
namespace HotelLeSequelle
{
    public static class UniversalMethods
    {


        public static Person LoggedInUser { get; set; }
        public static Administrator? LoggedInAdmin { get; set; }

        //Helpers
        public static int TryParseReadKey(int spanLow, int spanHigh)
        {
            int key = 0;
            bool success = false;
            while (!success)
            {
                Console.WriteLine($"Enter choise between {spanLow} and {spanHigh}");
                success = int.TryParse(Console.ReadKey().KeyChar.ToString(), out key);
                if (key < spanLow || key < spanHigh)
                {
                    success = false;
                }
                if (!success)
                {
                    Console.WriteLine("Incorrect entry!");
                    Console.WriteLine("Please try again");
                    Thread.Sleep(2000);
                    int cursorLeft;
                    int cursorTop;
                    (cursorLeft, cursorTop) = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorLeft, cursorTop - 2);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            return key;
        }
        public static int TryParseReadKey()
        {
            int key = 0;
            bool success = false;
            while (!success)
            {

                success = int.TryParse(Console.ReadKey().KeyChar.ToString(), out key);

                if (!success)
                {
                    Console.WriteLine("Incorrect entry!");
                    Console.WriteLine("Please try again");
                    Thread.Sleep(2000);
                    int cursorLeft;
                    int cursorTop;
                    (cursorLeft, cursorTop) = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorLeft, cursorTop - 2);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            return key;
        }
        public static int TryParseReadLine()
        {
            int entry = 0;
            bool success = false;
            while (!success)
            {
                success = int.TryParse(Console.ReadLine(), out entry);

                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(2);
                }
            }
            return entry;
        }
        public static int TryParseReadLine(int spanLow, int spanHigh)
        {
            int key = 0;
            bool success = false;
            while (!success)
            {
                Console.WriteLine($"Enter choise between {spanLow} and {spanHigh}");
                success = int.TryParse(Console.ReadLine(), out key);
                if (key < spanLow && key < spanHigh)
                {
                    success = false;
                }
                if (!success)
                {
                    Console.WriteLine("Incorrect entry!");
                    Console.WriteLine("Please try again");
                    Thread.Sleep(2000);
                    int cursorLeft;
                    int cursorTop;
                    (cursorLeft, cursorTop) = Console.GetCursorPosition();
                    Console.SetCursorPosition(cursorLeft, cursorTop - 2);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
            return key;
        }
        public static DateTime TryParseDateTime()
        {
            DateTime userEntry = DateTime.Now;
            bool success = false;
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out userEntry);

                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(2);
                }

            }
            return userEntry;
        }
        public static void TryParseDateTime(DateTime spanLow, DateTime spanHigh)
        {
            DateTime userEntry;
            bool success = false;
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out userEntry);

                if (userEntry < spanLow || userEntry > spanHigh)
                {
                    success = false;
                }
                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(1);
                }
            }
        }
        public static void TryParseDateTime(List<DateTime> unavailableDates)
        {
            DateTime userEntry;
            bool success = false;
            while (!success)
            {
                success = DateTime.TryParse(Console.ReadLine(), out userEntry);
                if (unavailableDates.Contains(userEntry))
                {
                    success = false;
                    Console.WriteLine("That date has already booked!");
                }
                if (!success)
                {
                    IncorrectEntryMessage();
                    ClearAboveCursor(1);
                }
            }
        }
        public static void ClearAboveCursor(int linesToClear)
        {
            int cursorLeft;
            int cursorTop;
            (cursorLeft, cursorTop) = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorLeft, cursorTop - linesToClear);
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void IncorrectEntryMessage()
        {
            Console.WriteLine("Incorrect entry!");
            Console.WriteLine("Please try again");
            Thread.Sleep(1500);
            ClearAboveCursor(2);

        }
        public static void PrintInMiddle(List<string> stringsToPrint)
        {
            foreach (var centeredString in stringsToPrint)
            {
                Console.SetCursorPosition(40, 3);
                Console.WriteLine(centeredString);
            }
        }
        public static void PrintInMiddle(string stringToPrint)
        {
            Console.SetCursorPosition(40, 3);
            Console.WriteLine(stringToPrint);
        }

        //Dev


        // Base

    }
}

