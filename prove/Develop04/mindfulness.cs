using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    protected abstract string GetActivityDescription();

    protected abstract List<string> GetPrompts();

    protected int GetDurationFromUser()
    {
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        int duration;

        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive integer.");
        }

        return duration;
    }

    protected void ShowSpinner(int seconds)
    {
        int counter = 0;
        int delay = 250; // milliseconds

        while (counter < seconds * 4)
        {
            counter++;
            Console.Write("\rProcessing |");

            switch (counter % 4)
            {
                case 0:
                    Console.Write("/");
                    break;
                case 1:
                    Console.Write("-");
                    break;
                case 2:
                    Console.Write("\\");
                    break;
                case 3:
                    Console.Write("|");
                    break;
            }

            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }

    protected void CountdownTimer(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write($"\r{i}...");
            Thread.Sleep(1000); // Wait for 1 second
        }

        Console.WriteLine();
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine(GetActivityDescription());
        Console.WriteLine("----------------------------------------------------");
        duration = GetDurationFromUser();

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        Console.WriteLine("Starting the activity...");

        PerformActivity();

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("Great job! You have completed the activity.");
        Console.WriteLine($"Total time: {duration} seconds.");
        Console.WriteLine("----------------------------------------------------");
        ShowSpinner(3);
    }

    protected abstract void PerformActivity();
}

class BreathingActivity : MindfulnessActivity
{
    protected override string GetActivityDescription()
    {
        return "Breathing Activity - Deep Breathing\nThis activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override List<string> GetPrompts()
    {
        return null; // Breathing activity does not require prompts
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Starting breathing session. Focus on your breath.");
        for (int i = 0; i < duration; i++)
        {
            Console.WriteLine("Breathe in...");
            CountdownTimer(3);

            Console.WriteLine("Breathe out...");
            CountdownTimer(3);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    protected override string GetActivityDescription()
    {
        return "Reflection Activity - Think Deeply\nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    protected override List<string> GetPrompts()
    {
        return new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Selecting a random prompt...");

        Random random = new Random();
        List<string> prompts = GetPrompts();

        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Take your time to think about the prompt and reflect on the questions.");

        List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        for (int i = 0; i < duration; i++)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine($"Question {i + 1}: {question}");

            ShowSpinner(3);
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    protected override string GetActivityDescription()
    {
        return "Listing Activity - Think Broadly\nThis activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override List<string> GetPrompts()
    {
        return new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Selecting a random prompt...");

        Random random = new Random();
        List<string> prompts = GetPrompts();

        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Take your time to think about the prompt and start listing items.");

        Console.WriteLine("Start listing as many things as you can related to this prompt.");
        Console.WriteLine("Press Enter after each item. To finish, enter 'done'.");

        string item;
        int count = 0;

        do
        {
            item = Console.ReadLine();

            if (item.ToLower() != "done")
                count++;
        } while (item.ToLower() != "done");

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine($"You listed {count} items. Well done!");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        while (true)
        {
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("0. Exit");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 0 and 3.");
            }

            if (choice == 0)
            {
                break;
            }

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
            }

            if (activity != null)
            {
                activity.Start();
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
    }
}

