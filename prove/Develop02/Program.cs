using System;

class Program
{
    static void Main(string[] args)
    {   
        string option;
        Entry input = new Entry();
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
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();
                string hourMinute = DateTime.Now.ToString("hh:mm tt");
                Console.WriteLine(dateText + "|" + hourMinute);
                break;
                //Display Journal Option
                case "2":

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