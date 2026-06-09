using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds requirements: reflection questions are selected without repeats
        // until every question has been shown once during an activity session.
        string choice = "";

        while (choice != "4")
        {
            Activity.ClearScreen();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == null)
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Please choose an option from 1 to 4.");
                    Activity pause = new Activity("", "");
                    pause.ShowSpinner(2);
                    break;
            }
        }
    }
}
