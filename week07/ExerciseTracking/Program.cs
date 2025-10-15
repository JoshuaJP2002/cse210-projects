using System;
using System.Collections.Generic;

abstract class Activity
{
    private DateTime _date;
    private double _minutes;

    public Activity(DateTime date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date { get { return _date; } }
    public double Minutes { get { return _minutes; } }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {this.GetType().Name} ({Minutes} min) - " +
               $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

class Running : Activity
{
    private double _distance;

    public Running(DateTime date, double minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / Minutes) * 60;
    public override double GetPace() => Minutes / _distance;
}

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * Minutes) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, double minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62; // miles
    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Console.WriteLine("Welcome to the Gym Activity Tracker!");
        Console.WriteLine("How many activities would you like to log?");
        int totalActivities = int.Parse(Console.ReadLine());

        for (int i = 0; i < totalActivities; i++)
        {
            Console.WriteLine($"\nActivity #{i + 1}:");

            // Validate activity type input
            string type = "";
            while (true)
            {
                Console.WriteLine("Activity type (Running, Cycling, Swimming):");
                type = Console.ReadLine().Trim();
                if (type.Equals("Running", StringComparison.OrdinalIgnoreCase) ||
                    type.Equals("Cycling", StringComparison.OrdinalIgnoreCase) ||
                    type.Equals("Swimming", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                Console.WriteLine("Invalid activity type. Please enter Running, Cycling, or Swimming.");
            }

            // Get date
            DateTime date;
            while (true)
            {
                Console.WriteLine("Date (yyyy-mm-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    break;
                Console.WriteLine("Invalid date format. Please try again.");
            }

            // Get duration
            double minutes;
            while (true)
            {
                Console.WriteLine("Duration in minutes:");
                if (double.TryParse(Console.ReadLine(), out minutes) && minutes > 0)
                    break;
                Console.WriteLine("Invalid number. Please enter a positive number of minutes.");
            }

            // Create the right type of activity
            switch (type.ToLower())
            {
                case "running":
                    double distance;
                    while (true)
                    {
                        Console.WriteLine("Distance in miles:");
                        if (double.TryParse(Console.ReadLine(), out distance) && distance > 0)
                            break;
                        Console.WriteLine("Invalid number. Please enter a positive distance.");
                    }
                    activities.Add(new Running(date, minutes, distance));
                    break;

                case "cycling":
                    double speed;
                    while (true)
                    {
                        Console.WriteLine("Speed in mph:");
                        if (double.TryParse(Console.ReadLine(), out speed) && speed > 0)
                            break;
                        Console.WriteLine("Invalid number. Please enter a positive speed.");
                    }
                    activities.Add(new Cycling(date, minutes, speed));
                    break;

                case "swimming":
                    int laps;
                    while (true)
                    {
                        Console.WriteLine("Number of 50-meter laps:");
                        if (int.TryParse(Console.ReadLine(), out laps) && laps > 0)
                            break;
                        Console.WriteLine("Invalid number. Please enter a positive number of laps.");
                    }
                    activities.Add(new Swimming(date, minutes, laps));
                    break;
            }
        }

        Console.WriteLine("\nSummary of all activities:");
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
