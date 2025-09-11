using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }

    public string ToFileString() => $"{_date}~|~{_prompt}~|~{_response}";

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("~|~");
        return parts.Length == 3 ? new Entry(parts[1], parts[2], parts[0]) : null;
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) => _entries.Add(entry);

    public void Display() { foreach (var entry in _entries) entry.Display(); }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
            foreach (var entry in _entries)
                writer.WriteLine(entry.ToFileString());
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) { Console.WriteLine("File not found.\n"); return; }
        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            Entry entry = Entry.FromFileString(line);
            if (entry != null) _entries.Add(entry);
        }
        Console.WriteLine("Journal loaded successfully!\n");
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    private Random _random = new Random();

    public string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Journal Menu:\n1. Write a new entry\n2. Display the journal\n3. Save the journal\n4. Load the journal\n5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd")));
                    Console.WriteLine("Entry added!\n");
                    break;

                case "2": journal.Display(); break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    journal.SaveToFile(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    journal.LoadFromFile(Console.ReadLine());
                    break;

                case "5": return;

                default: Console.WriteLine("Invalid option. Try again.\n"); break;
            }
        }
    }
}
