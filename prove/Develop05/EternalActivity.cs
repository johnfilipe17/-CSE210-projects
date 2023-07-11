using System;

class EternalActivity : Activity
{
    private readonly int _points;

    public int Points
    {
        get { return _points; }
    }

    public EternalActivity(string description, int points, string name, bool completed = false)
        : base(description, ActivityType.Eternal, name, completed)
    {
        _points = points;
    }

    public override int GetPoints()
    {
        return Completed ? _points : 0;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Eternal Activity: {_name}");
        Console.WriteLine($"Description: {_description}");
    }
}
