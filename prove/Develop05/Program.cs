using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Activity> activities = new List<Activity>();
    static int score = 0;

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("1. Create a new activity");
            Console.WriteLine("2. Record an event (accomplished activity)");
            Console.WriteLine("3. Show list of activities");
            Console.WriteLine("4. Display user's score");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateActivity();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowActivities();
                    break;
                case "4":
                    DisplayScore();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void CreateActivity()
    {
        Console.WriteLine("Select activity type:");
        Console.WriteLine("1. Simple goal (marked complete)");
        Console.WriteLine("2. Eternal goal (repeatedly recorded)");
        Console.Write("Enter activity type: ");
        string typeChoice = Console.ReadLine();

        ActivityType activityType;
        if (!Enum.TryParse(typeChoice, out activityType))
        {
            Console.WriteLine("Invalid activity type. Please try again.");
            return;
        }

        Console.Write("Enter activity name: ");
        string name = Console.ReadLine();

        Console.Write("Enter activity description: ");
        string description = Console.ReadLine();

        Activity activity;
        switch (activityType)
        {
            case ActivityType.Simple:
                Console.Write("Enter points for the activity: ");
                string pointsStr = Console.ReadLine();
                int points;
                if (!int.TryParse(pointsStr, out points) || points <= 0)
                {
                    Console.WriteLine("Invalid points. Please try again.");
                    return;
                }
                activity = new SimpleActivity(description, points, name);
                break;
            case ActivityType.Eternal:
                Console.Write("Enter points for the activity: ");
                string eternalPointsStr = Console.ReadLine();
                int eternalPoints;
                if (!int.TryParse(eternalPointsStr, out eternalPoints) || eternalPoints <= 0)
                {
                    Console.WriteLine("Invalid points. Please try again.");
                    return;
                }
                activity = new EternalActivity(description, eternalPoints, name);
                break;
            default:
                Console.WriteLine("Invalid activity type. Please try again.");
                return;
        }

        activities.Add(activity);
        Console.WriteLine("Activity created successfully.");
    }

    static void RecordEvent()
    {
        Console.WriteLine("Select an activity to record an event for:");
        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].Name}");
        }

        Console.Write("Enter activity number: ");
        string activityNumberStr = Console.ReadLine();
        int activityNumber;
        if (!int.TryParse(activityNumberStr, out activityNumber) || activityNumber < 1 || activityNumber > activities.Count)
        {
            Console.WriteLine("Invalid activity number. Please try again.");
            return;
        }

        Activity activity = activities[activityNumber - 1];
        activity.RecordEvent();
        score += activity.GetPoints();
        Console.WriteLine("Event recorded successfully.");
    }

    static void ShowActivities()
    {
        Console.WriteLine("List of activities:");
        for (int i = 0; i < activities.Count; i++)
        {
            Activity activity = activities[i];
            string completionStatus = activity.Completed ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {completionStatus} {activity.Name}");
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine($"Current score: {score} points");
    }
}
