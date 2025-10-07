using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < _goals.Count)
        {
            int pointsEarned = _goals[goalNumber].RecordEvent();
            _score += pointsEarned;

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");

            // Check for level up (exceeding requirements)
            CheckForLevelUp();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string goalType = parts[0];
            string[] goalData = parts[1].Split('|');

            switch (goalType)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        goalData[0],
                        goalData[1],
                        int.Parse(goalData[2]),
                        bool.Parse(goalData[3])
                    ));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(
                        goalData[0],
                        goalData[1],
                        int.Parse(goalData[2])
                    ));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        goalData[0],
                        goalData[1],
                        int.Parse(goalData[2]),
                        int.Parse(goalData[3]),
                        int.Parse(goalData[4]),
                        int.Parse(goalData[5])
                    ));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }

    // EXCEEDING REQUIREMENTS: Level system and negative goals
    private void CheckForLevelUp()
    {
        int oldLevel = _score / 1000;
        int newLevel = (_score + 1) / 1000; // Check if we just crossed a level boundary

        if (newLevel > oldLevel)
        {
            Console.WriteLine($"\n🎉 LEVEL UP! You reached level {newLevel}! 🎉");
            Console.WriteLine("Keep up the great work on your eternal quest!");
        }
    }
}