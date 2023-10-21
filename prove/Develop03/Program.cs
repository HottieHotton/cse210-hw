using System;

class Program
{
    static void Main(string[] args)
    {
        // Single Verse
        // var scripture = new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        
        // Two Verses
        var scripture = new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");

            while (!scripture.AllWordsHidden)
            {
                Console.Clear();
                Console.WriteLine(scripture);
                Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input == "quit") return;

                scripture.HideRandomWords();
            }

            Console.Clear();
            Console.WriteLine("All words are hidden!");
        }
    }