using System;
using System.Collections.Generic;

namespace JournalApp
{
    class PromptList
    {
        private List<string> prompts;

        public PromptList()
        {
            prompts = new List<string>();
            prompts.Add("Who was the most interesting person I talked to today?");
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
