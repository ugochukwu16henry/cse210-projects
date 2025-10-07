public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points, isComplete) { }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"{GetCheckbox()} {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name}|{_description}|{_points}|{_isComplete}";
    }
}