using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Samuel Bennet", "Multiplication");
        Console.WriteLine(assignment1.Getsummary());

        Console.WriteLine();

        MathAssingnmet math1 = new MathAssingnmet("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(math1.Getsummary());
        Console.WriteLine(math1.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment writing1 = new WritingAssignment("Mary waters", "European History", "The Causes of World War II");
        Console.WriteLine(writing1.Getsummary());
        Console.WriteLine(writing1.GetWritingInformation());
    }
}