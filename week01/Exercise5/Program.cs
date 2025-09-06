using System;

class Program
{
    static void Main()
    {
        // Step 1: Display welcome message
        DisplayWelcome();

        // Step 2: Ask for user's name
        string userName = PromptUserName();

        // Step 3: Ask for user's favorite number
        int favoriteNumber = PromptUserNumber();

        // Step 4: Square the number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Step 5: Display result
        DisplayResult(userName, squaredNumber);
    }

    // Function 1
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function 2
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function 3
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function 4
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function 5
    static void DisplayResult(string name, int squared)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
    }
}
