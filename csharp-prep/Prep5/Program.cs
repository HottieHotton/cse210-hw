using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
        DisplayMessage();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int square = SquareNumber(num);
        DisplayResult(name, square);
    }

    static void DisplayMessage(){
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName(){
        Console.WriteLine("Enter your name: ");
        string user = Console.ReadLine();
        return user;
    }
    static int PromptUserNumber(){
        Console.WriteLine("Enter your favorite integer: ");
        string input = Console.ReadLine();
        int num = int.Parse(input);
        return num;
    }
    static int SquareNumber(int num){
        int square = num*num;
        return square;
    }
    static void DisplayResult(string name, int number){
        Console.WriteLine($"{name}, the square of your number is {number}");
    }
}