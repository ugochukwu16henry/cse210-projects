using System;

public abstract class Activity
{
    private DateTime _date;
    private int _length; // in minutes

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public DateTime GetDate() => _date;
    public int GetLength() => _length;

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance(); // in miles or km
    public abstract double GetSpeed();    // in mph or kph
    public abstract double GetPace();     // in min per mile or min per km

    // Virtual method that can be overridden if needed
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_length} min) - " +
               $"Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}