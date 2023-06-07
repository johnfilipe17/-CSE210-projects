using System;

namespace JournalApp
{
    class JournalEntry
    {
        public string _prompt { get; }
        public string _response { get; }
        public DateTime _date { get; }

        public JournalEntry(string prompt, string response)
        {
            _prompt = prompt;
            _response = response;
            _date = DateTime.Now;
        }

        public JournalEntry(string prompt, string response, DateTime date)
        {
            _prompt = prompt;
            _response = response;
            _date = date;
        }

        public void DisplayEntry()
        {
            Console.WriteLine($"{_date}: {_prompt} - {_response}");
        }
    }
}
