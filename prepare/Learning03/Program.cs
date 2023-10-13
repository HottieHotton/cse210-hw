using System;

class Program
{
    static void Main(string[] args)
    {
        // 1/1 Fraction
        Fraction first = new Fraction();
        Console.WriteLine();
        Console.WriteLine(first.GetFractionString());
        Console.WriteLine(first.GetDecimalValue());

        //Whole Fraction
        Fraction second = new Fraction(5);
        Console.WriteLine();
        Console.WriteLine(second.GetFractionString());
        Console.WriteLine(second.GetDecimalValue());

        //Different fraction
        Fraction third = new Fraction(6, 8);
        Console.WriteLine();
        Console.WriteLine(third.GetFractionString());
        Console.WriteLine(third.GetDecimalValue());

        // 1/3 fraction
        Fraction fourth = new Fraction(1, 3);
        Console.WriteLine();
        Console.WriteLine(fourth.GetFractionString());
        Console.WriteLine(fourth.GetDecimalValue());
    }
}