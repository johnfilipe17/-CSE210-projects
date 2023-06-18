using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Activity> activities = new List<Activity>();
    static int score = 0;
    const string ActivitiesFileName = "activities.txt";
    const string ScoreFileName = "score.txt";

    static void Main()
    {
        LoadData();

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

            SaveData();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void CreateActivity()
    {
        Console.WriteLine("Select activity type:");
        Console.WriteLine("1. Simple goal (marked complete)");
        Console.WriteLine("2. Eternal goal (repeatedly recorded)");
        Console.WriteLine("3. Checklist goal (accomplished a certain number of times)");
        Console.Write("Enter activity type: ");
        string typeChoice = Console.ReadLine();

        ActivityType activityType;
        if (!Enum.TryParse(typeChoice, out activityType))
        {
            Console.WriteLine("Invalid activity type. Please try again.");
            return;
        }

        Console.Write("Enter activity description: ");
        string description = Console.ReadLine();

        Activity activity;
        switch (activityType)
        {
            case ActivityType.Simple:
                activity = new SimpleActivity(description, 1000);
                break;
            case ActivityType.Eternal:
                activity = new EternalActivity(description, 100);
                break;
            case ActivityType.Checklist:
                Console.Write("Enter desired number of completions: ");
                string completionCountStr = Console.ReadLine();
                int completionCount;
                if (!int.TryParse(completionCountStr, out completionCount) || completionCount <= 0)
                {
                    Console.WriteLine("Invalid completion count. Please try again.");
                    return;
                }
                activity = new ChecklistActivity(description, completionCount, 50, 500);
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
            Console.WriteLine($"{i + 1}. {activities[i].Description}");
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
            Console.WriteLine($"{i + 1}. {completionStatus} {activity.Description}");
        }
    }

    static void DisplayScore()
    {
        Console.WriteLine($"Current score: {score} points");
    }

    static void LoadData()
    {
        if (File.Exists(ActivitiesFileName))
        {
            string[] activityLines = File.ReadAllLines(ActivitiesFileName);
            foreach (string line in activityLines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 4)
                {
                    string activityTypeStr = parts[0];
                    string description = parts[1];
                    string completedStr = parts[2];
                    string completionCountStr = parts[3];

                    ActivityType activityType;
                    if (Enum.TryParse(activityTypeStr, out activityType))
                    {
                        switch (activityType)
                        {
                            case ActivityType.Simple:
                                activities.Add(new SimpleActivity(description, 0, bool.Parse(completedStr)));
                                break;
                            case ActivityType.Eternal:
                                activities.Add(new EternalActivity(description, 0, bool.Parse(completedStr)));
                                break;
                            case ActivityType.Checklist:
                                int completionCount;
                                if (int.TryParse(completionCountStr, out completionCount))
                                {
                                    activities.Add(new ChecklistActivity(description, completionCount, 0, 0, bool.Parse(completedStr)));
                                }
                                break;
                        }
                    }
                }
            }
        }

        if (File.Exists(ScoreFileName))
        {
            string scoreStr = File.ReadAllText(ScoreFileName);
            int savedScore;
            if (int.TryParse(scoreStr, out savedScore))
            {
                score = savedScore;
            }
        }
    }

    static void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(ActivitiesFileName))
        {
            foreach (Activity activity in activities)
            {
                string activityTypeStr = activity.Type.ToString();
                string description = activity.Description;
                string completedStr = activity.Completed.ToString();

                if (activity.Type == ActivityType.Checklist)
                {
                    ChecklistActivity checklistActivity = (ChecklistActivity)activity;
                    string completionCountStr = checklistActivity.CompletionCount.ToString();
                    writer.WriteLine($"{activityTypeStr}|{description}|{completedStr}|{completionCountStr}");
                }
                else
                {
                    writer.WriteLine($"{activityTypeStr}|{description}|{completedStr}");
                }
            }
        }

        File.WriteAllText(ScoreFileName, score.ToString());
    }
}

enum ActivityType
{
    Simple,
    Eternal,
    Checklist
}

abstract class Activity
{
    public string Description { get; }
    public bool Completed { get; protected set; }
    public ActivityType Type { get; }

    protected Activity(string description, ActivityType type, bool completed = false)
    {
        Description = description;
        Completed = completed;
        Type = type;
    }

    public abstract int GetPoints();

    public virtual void RecordEvent()
    {
        Completed = true;
    }
}

class SimpleActivity : Activity
{
    private readonly int points;

    public SimpleActivity(string description, int points, bool completed = false)
        : base(description, ActivityType.Simple, completed)
    {
        this.points = points;
    }

    public override int GetPoints()
    {
        return Completed ? points : 0;
    }
}

class EternalActivity : Activity
{
    private readonly int points;

    public EternalActivity(string description, int points, bool completed = false)
        : base(description, ActivityType.Eternal, completed)
    {
        this.points = points;
    }

    public override int GetPoints()
    {
        return Completed ? points : 0;
    }

    public override void RecordEvent()
    {
        Completed = true;
    }
}

class ChecklistActivity : Activity
{
    private readonly int desiredCompletionCount;
    private readonly int pointsPerCompletion;
    private readonly int bonusPoints;
    private int completionCount;

    public int CompletionCount => completionCount;
    public int DesiredCompletionCount => desiredCompletionCount;

    public ChecklistActivity(string description, int desiredCompletionCount, int pointsPerCompletion, int bonusPoints, bool completed = false)
        : base(description, ActivityType.Checklist, completed)
    {
        this.desiredCompletionCount = desiredCompletionCount;
        this.pointsPerCompletion = pointsPerCompletion;
        this.bonusPoints = bonusPoints;
    }

    public override int GetPoints()
    {
        int totalPoints = completionCount * pointsPerCompletion;
        if (Completed && completionCount >= desiredCompletionCount)
        {
            totalPoints += bonusPoints;
        }
        return totalPoints;
    }

    public override void RecordEvent()
    {
        completionCount++;
        Completed = completionCount >= desiredCompletionCount;
    }
}
