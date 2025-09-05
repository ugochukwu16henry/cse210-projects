using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Guess My Number!");

        while (true) // outer loop to allow replaying
        {
            PlayOneGame();

            Console.Write("Play again? (yes/no): ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (!(answer == "y" || answer == "yes"))
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
        }
    }

    static void PlayOneGame()
    {
        Random rnd = new Random();
        int magic = rnd.Next(1, 101); // random 1..100
        // Console.WriteLine($"(DEBUG magic = {magic})"); // enable for debugging

        int guesses = 0;
        while (true)
        {
            int guess = ReadInt("What is your guess? ");
            guesses++;

            if (guess < magic)
                Console.WriteLine("Higher");
            else if (guess > magic)
                Console.WriteLine("Lower");
            else
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"You took {guesses} guess{(guesses == 1 ? "" : "es")}.");
                break;
            }
        }
    }

    // Helper that repeatedly prompts until the user enters a valid integer
    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Please enter a valid whole number.");
        }
    }
}
