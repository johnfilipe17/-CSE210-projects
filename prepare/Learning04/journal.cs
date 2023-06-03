using System;
using System.Collections.Generic;
using System.IO;

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

    class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void AddEntry(JournalEntry entry)
        {
            entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine($"{entry.Date}: {entry.Prompt} - {entry.Response}");
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (JournalEntry entry in entries)
                {
                    sw.WriteLine($"{entry.Date}:{entry.Prompt}:{entry.Response}");
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            entries.Clear();
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    entries.Add(new JournalEntry(parts[1], parts[2], DateTime.Parse(parts[0])));
                }
            }
        }
    }

    class JournalEntry
    {
        public string Prompt { get; }
        public string Response { get; }
        public DateTime Date { get; }

        public JournalEntry(string prompt, string response)
        {
            Prompt = prompt;
            Response = response;
            Date = DateTime.Now;
        }

        public JournalEntry(string prompt, string response, DateTime date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }
    }

    class PromptList
    {
        private List<string> prompts;

        public PromptList()
        {
            prompts = new List<string>();
            prompts.Add("Who was the most interesting person I talked to  today?");
            prompts.Add("What was the highlight of my day?");
             prompts.Add("How did I see the hand of the Lord in my life today?");
            prompts.Add("What was the strongest emotion I felt today?");
            prompts.Add("If I had one thing I could do over today, what would it be?");
        }

        public string GetPrompt()
        {
            Random rand = new Random();
            return prompts[rand.Next(prompts.Count)];
        }
    }
}
