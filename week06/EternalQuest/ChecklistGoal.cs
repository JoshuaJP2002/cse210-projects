public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, string category, int points, int target, int bonus, int current = 0)
        : base(name, description, category, points)
    {
        _targetCount = target;
        _bonusPoints = bonus;
        _currentCount = current;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine($"'{_name}' is already complete.");
            return 0;
        }

        _currentCount++;
        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You completed '{_name}' and earned {_points + _bonusPoints} points!");
            return _points + _bonusPoints;
        }
        else
        {
            Console.WriteLine($"Progress recorded for '{_name}' ({_currentCount}/{_targetCount}) – earned {_points} points!");
            return _points;
        }
    }

    public override string GetStatus()
    {
        string check = _isComplete ? "[X]" : "[ ]";
        return $"{check} {_name} ({_description}) - Category: {_category} - Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_category}|{_points}|{_targetCount}|{_currentCount}|{_bonusPoints}";
    }
}
