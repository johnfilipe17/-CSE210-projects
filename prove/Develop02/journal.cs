using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
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
                entry.DisplayEntry();
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (JournalEntry entry in entries)
                {
                    sw.WriteLine($"{entry._date}:{entry._prompt}:{entry._response}");
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
}


