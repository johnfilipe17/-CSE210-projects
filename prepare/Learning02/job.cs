using System;
public class Job
{
    public string _jobTitle;
    public string _company;
    public int _yearStarted;
    public int _yearEnded;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {yearStarted}-{_yearEnded}");
    }

    public double DisplayJobDet();
}

