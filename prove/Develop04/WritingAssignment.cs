////Create this class and make sure to specify that it inherits from the base Assignment class.
public class WritingAssignment : Assignment
{
//Add the member variables and set up the constructor as you did for the MathAssignment class.
    private string _title;

    // Notice the syntax here that the WritingAssignment constructor has 3 parameters and then
    // it passes 2 of them directly to the "base" constructor, which is the "Assignment" class constructor.
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        // Here we set any variables specific to the WritingAssignment class
        _title = title;
    }

    //Add the GetWritingInformation() method.
    public string GetWritingInformation()
    {
        // Notice that we are calling the getter here because _studentName is private in the base class
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }

}

