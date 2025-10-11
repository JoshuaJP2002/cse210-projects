public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, string category, int points, bool complete = false)
        : base(name, description, category, points)
    {
        _isComplete = complete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"You completed '{_name}' and earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine($"'{_name}' is already complete.");
            return 0;
        }
    }

    public override string GetStatus()
    {
        string check = _isComplete ? "[X]" : "[ ]";
        return $"{check} {_name} ({_description}) - Category: {_category}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_name}|{_description}|{_category}|{_points}|{_isComplete}";
    }
}
