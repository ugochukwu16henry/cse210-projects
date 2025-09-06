using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new();

        while (true)
        {
            int num = ReadInt("Enter number: ");
            if (num == 0)
                break;
            numbers.Add(num);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int largest = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        // Stretch: smallest positive number
        var positives = numbers.Where(n => n > 0).ToList();
        if (positives.Count > 0)
        {
            Console.WriteLine($"The smallest positive number is: {positives.Min()}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers.");
        }

        // Stretch: sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
            Console.WriteLine(n);
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int value))
                return value;
            Console.WriteLine("Invalid number. Please enter a whole number.");
        }
    }
}
