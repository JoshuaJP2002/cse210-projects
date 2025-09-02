using System;

class Program
{
    static void Main(string[] args)
    {
    
        // ask the user for their name
        Console.WriteLine("What is your first name? ");
        string name = Console.ReadLine();
        
        // ask the user for their lastname
        Console.WriteLine("What is your last name? ");
        string lastname = Console.ReadLine();

        Console.WriteLine($"Your name is {lastname}, {name} {lastname}");
    }
}