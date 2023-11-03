using System;

class Program
{
    static void Main(string[] args)
    {
        string choice;
        bool cont = true;

        while(cont == true){
            Console.WriteLine("Welcome to the Mindfullness Program!\n");
            Console.WriteLine("Choose one of the following options:\n1: Breathing Activity\n2: Reflection Activity\n3: Listing Activity\n4: Quit\n");

            Console.WriteLine("You choose: ");
            choice = Console.ReadLine();

            switch(choice){
                case "1": break;
                case "2": break;
                case "3": break;
                case "4":
                Console.WriteLine("Goodbye!");
                cont = false;
                break;
            }
        }
    }
}