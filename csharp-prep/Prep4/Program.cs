using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        int sum=0;
        int max = 0;
        int minPositive = 0;
        int num;
        string input;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished!");
        do{
            Console.WriteLine("Enter number: ");
            input = Console.ReadLine();
            num = int.Parse(input);

            if(num != 0){
                numbers.Add(num);
            }
        }while(num !=0);

        //Adding
        foreach(int add in numbers){
            sum += add;
        }

        //Average
        double average = numbers.Average();

        //Min and Max num
        max = numbers.Max();
        minPositive = numbers.Where(x => x >= 0).Min();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {Math.Round(average, 2)}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {minPositive}");
        Console.WriteLine("The sorted list is: ");
        numbers.Sort();
        foreach (int i in numbers){
            Console.WriteLine(i);
        }
    }
}