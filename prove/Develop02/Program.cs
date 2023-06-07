using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            PromptList promptList = new PromptList();
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");

                int choice = GiveChoice(1, 5);

                switch (choice)
                {
                    case 1:
                        string prompt = promptList.GetPrompt();
                        Console.WriteLine(prompt);
                        string response = Console.ReadLine();
                        journal.AddEntry(new JournalEntry(prompt, response));
                        Console.WriteLine("Info added.");
                        break;

                    case 2:
                        journal.DisplayEntries();
                        break;

                    case 3:
                        Console.WriteLine("Enter a filename to save to:");
                        string filename = Console.ReadLine();
                        journal.SaveToFile(filename);
                        Console.WriteLine("Journal saved.");
                        break;

                    case 4:
                        Console.WriteLine("Enter a filename to load from:");
                        filename = Console.ReadLine();
                        journal.LoadFromFile(filename);
                        Console.WriteLine("Journal loaded.");
                        break;

                    case 5:
                        quit = true;
                        break;
                }
            }
        }

        static int GiveChoice(int min, int max)
        {
            int choice = min - 1;
            while (choice < min || choice > max)
            {
                Console.Write($"Enter a number between {min} and {max}: ");
                int.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
    }
}