using System;

class Program
{
    static void Main()
    {
        // Ask for the grade percentage and validate the input
        
        int grade;
        Console.Write("Enter your grade percentage (0-100): ");
        string input = Console.ReadLine();

        while (!int.TryParse(input, out grade) || grade < 0 || grade > 100)
        {
            Console.WriteLine("Please enter a whole number between 0 and 100.");
            Console.Write("Enter your grade percentage (0-100): ");
            input = Console.ReadLine();
        }

        // 1) Determine the letter grade (A, B, C, D, F)
        string letter;
        if (grade >= 90)
            letter = "A";
        else if (grade >= 80)
            letter = "B";
        else if (grade >= 70)
            letter = "C";
        else if (grade >= 60)
            letter = "D";
        else
            letter = "F";

        // 2) Determine the sign (+, -, or empty string)
        string sign = "";
        int lastDigit = grade % 10;

        // Special-case: no signs for F
        if (letter == "F")
        {
            sign = "";
        }
        else if (letter == "A")
        {
            // There is no A+. Allow A- (when lastDigit < 3) but do not give A+.
            // Also treat a perfect 100 as plain A.
            if (grade == 100)
            {
                sign = "";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            // otherwise keep sign = ""
        }
        else
        {
            // For B, C, D: + if lastDigit >= 7, - if lastDigit < 3
            if (lastDigit >= 7)
                sign = "+";
            else if (lastDigit < 3)
                sign = "-";
        }

        // 3) Print letter+sign once
        Console.WriteLine($"Your grade is {letter}{sign}.");

        // 4) Separate pass/fail check (>= 70 passes)
        if (grade >= 70)
            Console.WriteLine("Congratulations — you passed the course!");
        else
            Console.WriteLine("Keep going — you did not pass this time, but you can improve!");
    }
}
