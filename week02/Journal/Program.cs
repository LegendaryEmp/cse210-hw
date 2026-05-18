using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string userInput = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(userInput, out choice))
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
                Console.WriteLine();
                continue;
            }

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine() ?? "";

                Console.Write("How would you describe your mood in one word? ");
                string mood = Console.ReadLine() ?? "";
                Console.WriteLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._mood = mood;

                journal.AddEntry(newEntry);
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine() ?? "";

                if (System.IO.File.Exists(file))
                {
                    journal.LoadFromFile(file);
                    Console.WriteLine("Journal loaded.");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }

                Console.WriteLine();
            }
            else if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine() ?? "";
                journal.SaveToFile(file);
                Console.WriteLine("Journal saved.");
                Console.WriteLine();
            }
            else if (choice != 5)
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
                Console.WriteLine();
            }
        }
    }
}
