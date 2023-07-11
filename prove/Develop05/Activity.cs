using System;

abstract class Activity
{
    private string _description;
    private bool _completed;
    private ActivityType _type;
    private string _name;

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public bool Completed
    {
        get { return _completed; }
        protected set { _completed = value; }
    }

    public ActivityType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    protected Activity(string description, ActivityType type, string name, bool completed = false)
    {
        _description = description;
        _completed = completed;
        _type = type;
        _name = name;
    }

    public abstract int GetPoints();

    public virtual void RecordEvent()
    {
        _completed = true;
    }

    public abstract void DisplayGoal();
}
