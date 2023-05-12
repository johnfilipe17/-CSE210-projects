using System;
using System.Collections.Generic;
using System.IO;

class Program {
    static void Main(string[] args) {
        // Create a new journal instance
        Journal journal = new Journal();

        // Main program loop
        bool running = true;
        while (running) {
            // Display options
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            // Get user input
            string input = Console.ReadLine();

            // Process user input
            switch (input) {
                case "1":
                    journal.WriteNewEntry();
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.WriteLine("\nEnter file name:");
                    string fileName = Console.ReadLine();
                    journal.SaveToFile(fileName);
                    break;

                case "4":
                    Console.WriteLine("\nEnter file name:");
                    fileName = Console.ReadLine();
                    journal.LoadFromFile(fileName);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }

        // Farewell message
        Console.WriteLine("\nGoodbye!");
    }
}

class Journal {
    private List<Entry> entries = new List<Entry>();
    private Random random = new Random();
    private List<string> prompts = new List<string> {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today?",
        "What was the most challenging part of my day?",
        "What are some goals I want to accomplish tomorrow?"
    };

    public void WriteNewEntry() {
        // Get a random prompt
        string prompt = prompts[random.Next(prompts.Count)];

        // Get user input for the response
        Console.WriteLine("\n{0}", prompt);
        string response = Console.ReadLine();

        // Create a new Entry instance and add it to the list of entries
        Entry newEntry = new Entry(prompt, response, DateTime.Now);
        entries.Add(newEntry);

        Console.WriteLine("\nEntry added successfully.");
    }

    public void DisplayEntries() {
        if (entries.Count == 0) {
            Console.WriteLine("\nNo entries to display.");
        } else {
            Console.WriteLine("\nJournal Entries:");
            foreach (Entry entry in entries) {
                Console.WriteLine("Date: {0}", entry.Date);
                Console.WriteLine("Prompt: {0}", entry.Prompt);
                Console.WriteLine("Response: {0}\n", entry.Response);
            }
        }
    }

    public void SaveToFile(string fileName) {
        try {
            using (StreamWriter writer = new StreamWriter(fileName)) {
                foreach (Entry entry in entries) {
                    writer.WriteLine("{0}|{1}|{2}", entry.Date, entry.Prompt, entry.Response);
                }
            }
            Console.WriteLine("\nJournal saved to file successfully.");
        } catch (IOException e) {
            Console.WriteLine("\nError saving journal to file: {0}", e.Message);
        }
    }

    public void LoadFromFile(string fileName) {
        try {
            List<Entry> newEntries = new List<Entry>();
            using (StreamReader reader = new StreamReader(fileName)) {
               
