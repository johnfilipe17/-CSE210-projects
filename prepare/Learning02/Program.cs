using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 =new Job();
        job1._jobTitle = "salesman";
        job1._company = "Dunder Mifflin";
        job1._yearStarted = 2005;
        job1._yearEnded = 2008;


        Job job2 = new Job();
        job2._jobTitle = "Assistant to the Regional Manager";
        job2._company = "Dunder Mifflin";
        job2._yearStarted = 2008;
        job2._yearEnded = 2011;


        Job job3 = new Job();
        job3._jobTitle = "Regional Manager";
        job3._company = "Dunder Mifflin";
        job3._yearStarted = 2011;
        job3._yearEnded = 2023;

        Resume myResume = new Resume();
        myResume._name = "Dwight Shrute";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);

        myResume.Display();

    }
}