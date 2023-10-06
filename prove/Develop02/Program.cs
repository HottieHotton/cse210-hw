using System;

class Program
{
    static void Main(string[] args)
    {   
        string option;
        Journal journal = new Journal();

        Console.WriteLine("Welcome to your Journal!\n");
        do{
            Console.WriteLine("Please enter a selection:");
            Console.WriteLine("1. Enter Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Jornal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("0. Quit\n");
            option = Console.ReadLine();

            switch(option){
                //Entry Option
                case "1":
                Entry input = new Entry();
                DateTime theCurrentTime = DateTime.Now;
                input._date = theCurrentTime.ToShortDateString();
                input._time = DateTime.Now.ToString("hh:mm tt");
                Console.WriteLine(input._prompt = input.GetPrompt());
                input._entry = Console.ReadLine();
                journal._journalList.Add(input);
                input.Display();
                break;
                //Display Journal Option
                case "2":
                journal.Display();
                break;
                //Save Journal
                case "3":
                
                break;
                //Load Journal
                case "4":
                
                break; 
            }
        }while(option != "0");
    }
}