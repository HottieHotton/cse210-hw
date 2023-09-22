using System;

class Program
{
    static void Main(string[] args)
    {
        string guess;
        string magic;
        bool match = false;
        int count = 0;
        Console.WriteLine("Hello Prep3 World!\n");

        Console.Write("What is your magic number? ");
        magic = Console.ReadLine();
        int numMagic = int.Parse(magic);
        do{
            Console.WriteLine("What is your guess? ");
            guess = Console.ReadLine();
            int numGuess = int.Parse(guess);

            if(numGuess < numMagic){
                Console.WriteLine("Higher!");
                count++;
            }else if(numGuess > numMagic){
                Console.WriteLine("Lower!");
                count++;
            }else if(numGuess == numMagic){
                count++;
                Console.WriteLine($"You got it! It took you {count} tries!");
                match = true;
            }
        }while(match != true);
    }
}