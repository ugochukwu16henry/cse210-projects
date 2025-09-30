using System;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing",
                  "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            Start();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            Console.WriteLine();

            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in... ");
                ShowCountdown(4);
                Console.WriteLine();

                if (DateTime.Now >= endTime) break;

                Console.Write("Breathe out... ");
                ShowCountdown(6);
                Console.WriteLine();
                Console.WriteLine();
            }

            End();
        }
    }
}