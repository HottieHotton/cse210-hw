using System;

class Program
{
    static void Main(string[] args)
    {   
        //Creates variables to set up the bast of the program
        string option;
        Journal journal = new Journal();
        SaveLoad file = new SaveLoad();

        Console.WriteLine("Welcome to your Journal!\n");
        //Do-While loop to keep program running
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
                Console.WriteLine();
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
                Console.WriteLine("\nWhat would you like your File Name to be?");
                file._fileName = Console.ReadLine();
                file.SaveFile(journal._journalList);
                break;
                //Load Journal
                case "4":
                Console.WriteLine("\nWhat is the name of the file you wish to load?");
                file._fileName = Console.ReadLine();
                journal._journalList.Clear();
                journal._journalList = file.LoadFile();
                Console.WriteLine("\nLoading Journal...\n");
                journal.Display();
                break; 
            }
        }while(option != "0");
    }
}