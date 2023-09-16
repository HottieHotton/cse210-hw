using System;

class Program
{
    static void Main(string[] args)
    {
        string percent = null;
        string grade = null;
        Console.WriteLine("Hello Prep2 World!");

        Console.Write("What is your percentage? ");
        percent = Console.ReadLine();
        int num = int.Parse(percent);

        //Grading System, starting with A Grade
        if (num >= 90)
        {
            if (num >= 94)
            {
                grade = "A";
            }
            else
            {
                grade = "A-";
            }
        }
        //B Grade
        else if (num <= 89 && num >= 80)
        {
            if (num >= 87)
            {
                grade = "B+";
            }
            else if (num >= 84 && num < 87)
            {
                grade = "B";
            }
            else
            {
                grade = "B-";
            }
        }
        //C Grade
        else if (num <= 79 && num >= 70)
        {
            if (num >= 77)
            {
                grade = "C+";
            }
            else if (num >= 74 && num < 77)
            {
                grade = "C";
            }
            else
            {
                grade = "C-";
            }
        }
        //D Grade
        else if (num <= 69 && num >= 60)
        {
            if (num >= 67)
            {
                grade = "D+";
            }
            else if (num >= 64 && num < 67)
            {
                grade = "D";
            }
            else
            {
                grade = "D-";
            }
        }
        //F Grade
        else if (num < 60)
        {
            grade = "F";
        }

    //Printing Results    
    if(num>=70){
        Console.WriteLine($"You have a {num}%, which is a {grade}! Great Job!");
    }else{
        Console.WriteLine($"You have a {num}%, which is a {grade}. Try again, you can do this!");
    }
    }
}