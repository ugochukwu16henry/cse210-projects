using System;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity!");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();

            // Get duration from user
            Console.Write("How long, in seconds, would you like for your session? ");
            _duration = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("|");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}