using System;

class Program
{
    static void Main(string[] args)
    {
        string user;
        SaveLoad saveload = new SaveLoad();
        Console.WriteLine("Welcome to Eternal Quest!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Manage Goals");
            Console.WriteLine("2. Show Score");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            user = Console.ReadLine();

            switch (user)
            {
                case "1":
                    ManageGoals();
                    break;
                case "2":
                    // goal.ShowScore();
                    break;
                case "3":
                    saveload.SaveGoals();
                    break;
                case "4":
                    saveload.LoadGoals();
                    break;
                case "0":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        void ManageGoals(){
            Console.WriteLine("Test");
        }
    }
}