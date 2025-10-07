using System;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public Goal(string name, string description, int points, bool isComplete)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    public abstract int RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    public string GetName() => _name;
    public bool IsComplete() => _isComplete;

    protected string GetCheckbox()
    {
        return _isComplete ? "[X]" : "[ ]";
    }
}