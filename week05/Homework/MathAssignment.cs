using System;

public class MathAssingnmet : Assignment
{
    private string _TextbookSection;
    private string _problems;

    public MathAssingnmet(string studentName, string topic, string textbooksection, string problems) : base(studentName, topic)
    {
        _TextbookSection = textbooksection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_TextbookSection} Problems {_problems}";
    }
}