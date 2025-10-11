using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points. (Level {_level})");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter goal category (Spiritual/Physical/Intellectual/Social): ");
        string category = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (choice == "1")
        {
            goal = new SimpleGoal(name, desc, category, points);
        }
        else if (choice == "2")
        {
            goal = new EternalGoal(name, desc, category, points);
        }
        else if (choice == "3")
        {
            Console.Write("Enter target number of completions: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points when completed: ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, desc, category, points, target, bonus);
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetStatus()}");
            i++;
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("\nSelect the goal you accomplished:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }

        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;

            UpdateLevel();
            ShowMotivation();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_level);
            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];
            string name = parts[1];
            string desc = parts[2];
            string category = parts[3];
            int points = int.Parse(parts[4]);

            if (type == "SimpleGoal")
            {
                bool complete = bool.Parse(parts[5]);
                _goals.Add(new SimpleGoal(name, desc, category, points, complete));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, desc, category, points));
            }
            else if (type == "ChecklistGoal")
            {
                int target = int.Parse(parts[5]);
                int current = int.Parse(parts[6]);
                int bonus = int.Parse(parts[7]);
                _goals.Add(new ChecklistGoal(name, desc, category, points, target, bonus, current));
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    private void UpdateLevel()
    {
        _level = (_score / 1000) + 1;
    }

    private void ShowMotivation()
    {
        string[] messages =
        {
            "Keep it up! You're doing amazing!",
            "One step closer to greatness!",
            "Your consistency is paying off!",
            "The journey of a thousand miles begins with one step!",
            "You’re becoming unstoppable!"
        };
        Random rand = new Random();
        Console.WriteLine(messages[rand.Next(messages.Length)]);
    }
}
