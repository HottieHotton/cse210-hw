using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Braxton Hotton", "C# Programming");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment math = new MathAssignment("Braxton Hotton", "Multiplication", "5.2", "1-5");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        WritingAssignment writing = new WritingAssignment("Braxton Hotton", "US History", "Rise of Technology");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}