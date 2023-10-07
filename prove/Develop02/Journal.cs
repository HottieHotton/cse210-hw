using System;
using System.Collections.Generic;

class Journal{
    public List<Entry> _journalList = new List<Entry>();

    //Method to Display current List of entries
    public void Display(){
        Console.WriteLine("Journal Entries: ");
        foreach (Entry jEntry in _journalList)
        {
            jEntry.Display();
        }
    }
}