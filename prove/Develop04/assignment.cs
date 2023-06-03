public class Assignment  {

// add the attributes as private member variables.
    private string _studentName;
    private string _topic;

    //Create a constructor for this class that receives a student name and topic and sets the member variables.
    public Assignment(string studentName,string topic) {
        _studentName = studentName;
        _topic = topic;
    }

    // We will provide Getters for our private member variables so they can be accessed
    // later both outside the class as well is in derived classes.

    //this is a method, or a function:
    public string GetStudentName(){
        return _studentName;
    }

    //this is a method, or a function, the second:
    public string GetTopic()
    {
        return _topic;
    }

    //this is a method, or a function the third and last:
    public string GetSummary()
    {
        return _studentName + "-" +_topic;
    }

    //Add the method for GetSummary() to return the student's name and the topic.

}

 
