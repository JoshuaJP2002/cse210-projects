using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    protected string GetStudentName()
    {
        return _studentName;
    }

    public string Getsummary()
    {
        return $"{_studentName} - {_topic}";
    }

}