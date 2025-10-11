public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string category, int points)
        : base(name, description, category, points) { }

    public override int RecordEvent()
    {
        Console.WriteLine($"You recorded '{_name}' and earned {_points} points!");
        return _points;
    }

    public override string GetStatus()
    {
        return $"[∞] {_name} ({_description}) - Category: {_category}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{_category}|{_points}";
    }
}
