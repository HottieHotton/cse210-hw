using System;

class Program
{
    static void Main(string[] args)
    {
        string choice;
        bool cont = true;

        while(cont == true){
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfullness Program!\n");
            Console.WriteLine("Choose one of the following options:\n1: Breathing Activity\n2: Reflection Activity\n3: Listing Activity\n4: Quit\n");

            Console.WriteLine("You choose: ");
            choice = Console.ReadLine();

            switch(choice){
                case "1":
                Console.Clear();
                BreathingActivity breathing = new BreathingActivity();
                breathing.StartMessage();
                break;
                case "2":
                Console.Clear();
                ReflectionActivity reflecting = new ReflectionActivity();
                reflecting.StartMessage();
                break;
                case "3":
                Console.Clear();
                ListingActivity listing = new ListingActivity();
                listing.StartMessage();
                break;
                case "4":
                Console.Clear();
                Console.WriteLine("Goodbye!");
                cont = false;
                break;
                default:
                Console.Clear(); 
                Console.WriteLine("You have enter an invalid option, please try again!\n");
                Console.Clear();
                break;
            }
        }
    }
}