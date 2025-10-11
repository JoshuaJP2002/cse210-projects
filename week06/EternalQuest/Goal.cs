using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected string _category;
    protected int _points;
    protected bool _isComplete;

    public string Name => _name;

    public Goal(string name, string description, string category, int points)
    {
        _name = name;
        _description = description;
        _category = category;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();
}
