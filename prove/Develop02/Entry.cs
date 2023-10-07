using System;

class Entry{
    public string _date;
    public string _time;
    public string _entry;
    public string _prompt;

    //Method to display prompt for user
    public string GetPrompt(){
        Random rnd = new Random();
        int num = rnd.Next(0,4);
        string[] promptArray = {"What did you do today?",
        "Who did you inspire today?",
        "What inspires you to keep going day to day?",
        "Did you remember to compliment your spouse?",
        "What reminded you of the Gospel today?"};
        string prompt = promptArray[num];
        return prompt;
    }

    //Method to display submitted Entry and helps the Journal Dispaly method
    public void Display(){
        Console.WriteLine($"{_date}|{_time}|{_prompt}|{_entry}");
    }

    //Method to help the SaveLoad method
    public string AddLine(){
        return $"{_date}|{_time}|{_prompt}|{_entry}";
    }
}