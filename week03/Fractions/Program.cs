using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Testing Fraction Class:");
        Console.WriteLine("=======================");

        // Test constructors
        Console.WriteLine("\n1. Testing Constructors:");
        Fraction f1 = new Fraction();        // 1/1
        Fraction f2 = new Fraction(5);       // 5/1
        Fraction f3 = new Fraction(3, 4);    // 3/4
        Fraction f4 = new Fraction(1, 3);    // 1/3

        Console.WriteLine($"f1: {f1.GetFractionString()}");
        Console.WriteLine($"f2: {f2.GetFractionString()}");
        Console.WriteLine($"f3: {f3.GetFractionString()}");
        Console.WriteLine($"f4: {f4.GetFractionString()}");

        // Test getters and setters
        Console.WriteLine("\n2. Testing Getters and Setters:");
        Console.WriteLine($"Original f1 top: {f1.GetTop()}");
        Console.WriteLine($"Original f1 bottom: {f1.GetBottom()}");

        f1.SetTop(7);
        f1.SetBottom(8);
        Console.WriteLine($"After setting - f1 top: {f1.GetTop()}");
        Console.WriteLine($"After setting - f1 bottom: {f1.GetBottom()}");
        Console.WriteLine($"f1 as fraction: {f1.GetFractionString()}");

        // Test decimal values
        Console.WriteLine("\n3. Testing Decimal Values:");
        Console.WriteLine($"f1 decimal: {f1.GetDecimalValue()}");
        Console.WriteLine($"f2 decimal: {f2.GetDecimalValue()}");
        Console.WriteLine($"f3 decimal: {f3.GetDecimalValue()}");
        Console.WriteLine($"f4 decimal: {f4.GetDecimalValue()}");

        // Test with different fractions
        Console.WriteLine("\n4. Testing Additional Fractions:");
        Fraction f5 = new Fraction(2, 3);
        Console.WriteLine($"2/3 as fraction: {f5.GetFractionString()}");
        Console.WriteLine($"2/3 as decimal: {f5.GetDecimalValue():F3}");

        Fraction f6 = new Fraction(7, 2);
        Console.WriteLine($"7/2 as fraction: {f6.GetFractionString()}");
        Console.WriteLine($"7/2 as decimal: {f6.GetDecimalValue():F1}");
    }
}