using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create activities of each type
        List<Activity> activities = new List<Activity>();

        // Create a running activity
        Running running = new Running(new DateTime(2024, 11, 3), 30, 3.0);
        activities.Add(running);

        // Create a cycling activity
        Cycling cycling = new Cycling(new DateTime(2024, 11, 3), 30, 12.0);
        activities.Add(cycling);

        // Create a swimming activity
        Swimming swimming = new Swimming(new DateTime(2024, 11, 3), 30, 40);
        activities.Add(swimming);

        // Create additional activities to demonstrate variety
        Running running2 = new Running(new DateTime(2024, 11, 4), 45, 4.5);
        activities.Add(running2);

        Cycling cycling2 = new Cycling(new DateTime(2024, 11, 5), 60, 15.0);
        activities.Add(cycling2);

        // Display summaries for all activities
        Console.WriteLine("Exercise Tracking Summary");
        Console.WriteLine("=========================");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine(); // Add blank line between activities
        }
    }
}