using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Exceeds requirements: this program uses a small library of scriptures
        // and chooses one at random each time it runs. It also hides only words
        // that are still visible, which makes the memorization practice smoother.
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "And behold, I tell you these things that ye may learn wisdom that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.")
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsCompletelyHidden())
        {
            ClearScreen();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (input != null && input.ToLower() == "quit")
            {
                return;
            }

            scripture.HideRandomWords(3);
        }

        ClearScreen();
        Console.WriteLine(scripture.GetDisplayText());
    }

    static void ClearScreen()
    {
        try
        {
            Console.Clear();
        }
        catch (System.IO.IOException)
        {
        }
    }
}
