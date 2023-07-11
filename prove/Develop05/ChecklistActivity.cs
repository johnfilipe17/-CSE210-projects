using System;

class ChecklistActivity : Activity
{
    private readonly int _desiredCompletionCount;
    private readonly int _pointsPerCompletion;
    private readonly int _bonusPoints;
    private int _completionCount;

    public int CompletionCount
    {
        get { return _completionCount; }
        set { _completionCount = value; }
    }

    public int DesiredCompletionCount
    {
        get { return _desiredCompletionCount; }
    }

    public ChecklistActivity(string description, int desiredCompletionCount, int pointsPerCompletion, int bonusPoints, string name, bool completed = false)
        : base(description, ActivityType.Checklist, name, completed)
    {
        _desiredCompletionCount = desiredCompletionCount;
        _pointsPerCompletion = pointsPerCompletion;
        _bonusPoints = bonusPoints;
    }

    public override int GetPoints()
    {
        int totalPoints = _completionCount * _pointsPerCompletion;
        if (Completed && _completionCount >= _desiredCompletionCount)
        {
            totalPoints += _bonusPoints;
        }
        return totalPoints;
    }

    public override void RecordEvent()
    {
        _completionCount++;
        Completed = _completionCount >= _desiredCompletionCount;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Checklist Activity: {_name}");
        Console.WriteLine($"Description: {_description}");
    }
}
