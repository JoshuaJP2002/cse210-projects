using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing", "This activity will help you reflect on the good things in your life by listing as many as you can.") {}

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        Random rand = new Random();

        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You will begin in: ");
        Countdown(3);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
                items.Add(entry);
        }

        Console.WriteLine($"You listed {items.Count} items!");
        DisplayEndingMessage();
    }
}
