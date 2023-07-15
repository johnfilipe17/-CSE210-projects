using System;
using System.Collections.Generic;

public class Activity
{
    private DateTime date;
    protected int length;

    public Activity(DateTime date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} - Unknown Activity";
    }
}

public class RunningActivity : Activity
{
    private double distance;

    public RunningActivity(DateTime date, int length, double distance)
        : base(date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / length * 60; // Assuming distance is in miles and length is in minutes
    }

    public override double GetPace()
    {
        return length / distance; // Assuming distance is in miles and length is in minutes
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Running ({length} min) - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

public class CyclingActivity : Activity
{
    private double speed;

    public CyclingActivity(DateTime date, int length, double speed)
        : base(date, length)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed; // Assuming speed is in mph
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Cycling ({length} min) - Speed: {speed} mph, Pace: {GetPace()} min/mile";
    }
}

public class SwimmingActivity : Activity
{
    private int laps;
    private const double LapLengthInMeters = 50;

    public SwimmingActivity(DateTime date, int length, int laps)
        : base(date, length)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * LapLengthInMeters / 1000; // Distance in kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / length * 60; // Assuming distance is in kilometers and length is in minutes
    }

    public override double GetPace()
    {
        return length / GetDistance(); // Assuming distance is in kilometers and length is in minutes
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Swimming ({length} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min/km";
    }
}

public class FitnessApp
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create instances of each activity type
        Activity runningActivity = new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0);
        Activity cyclingActivity = new CyclingActivity(new DateTime(2022, 11, 3), 30, 6.0);
        Activity swimmingActivity = new SwimmingActivity(new DateTime(2022, 11, 3), 30, 10);

        // Add activities to the list
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        // Display the summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
