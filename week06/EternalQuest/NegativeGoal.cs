public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        // Negative goals subtract points when recorded
        return -_points;
    }

    public override string GetDetailsString()
    {
        return $"{GetCheckbox()} {_name} ({_description}) - AVOID THIS! (-{_points} points if done)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name}|{_description}|{_points}";
    }
}