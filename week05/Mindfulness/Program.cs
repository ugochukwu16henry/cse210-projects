using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exceeding Requirements: Added activity logging and session statistics
            ActivityLogger logger = new ActivityLogger();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("====================");
                Console.WriteLine();
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Activity Statistics");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Choose an activity (1-5): ");

                string choice = Console.ReadLine();

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        ShowStatistics(logger);
                        continue;
                    case "5":
                        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        continue;
                }

                if (activity != null)
                {
                    activity.Run();
                    logger.LogActivity(activity.GetType().Name);
                }

                Console.WriteLine();
                Console.Write("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void ShowStatistics(ActivityLogger logger)
        {
            Console.Clear();
            Console.WriteLine("Activity Statistics");
            Console.WriteLine("===================");
            Console.WriteLine();

            var stats = logger.GetStatistics();
            if (stats.Count == 0)
            {
                Console.WriteLine("No activities completed yet.");
            }
            else
            {
                foreach (var stat in stats)
                {
                    Console.WriteLine($"{stat.Key}: {stat.Value} times");
                }
            }

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }

    // Exceeding Requirements: Activity logging system
    public class ActivityLogger
    {
        private Dictionary<string, int> _activityCounts = new Dictionary<string, int>();

        public void LogActivity(string activityName)
        {
            if (_activityCounts.ContainsKey(activityName))
            {
                _activityCounts[activityName]++;
            }
            else
            {
                _activityCounts[activityName] = 1;
            }
        }

        public Dictionary<string, int> GetStatistics()
        {
            return new Dictionary<string, int>(_activityCounts);
        }
    }
}