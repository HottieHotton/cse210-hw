using System;
using System.IO;

class SaveLoad{
    public string _fileName;

    //Method that saves to a file name of choice and uses AddLine method in Entry
    public void SaveFile(List<Entry> newList){
        using(StreamWriter outputFile = new StreamWriter(_fileName)){
            foreach(Entry entry in newList){
                outputFile.WriteLine(entry.AddLine());
            }
        }
        Console.WriteLine($"File Saved under the name {_fileName}");
    }

    //Method to Load Journal by filename and returns the new list of entries
    public List<Entry> LoadFile(){
        //Creates new List to return
        List<Entry> newList = new List<Entry>();
        //Grabs data from file and creates array
        string[] lines = File.ReadAllLines(_fileName);
        //Itterates through array, splits it into 4 parts into the specified entry objects, then adds to the List
        foreach(string newLine in lines){
            Entry entry = new Entry();
            string[] parts = newLine.Split("|");
            entry._date = parts[0];
            entry._time = parts[1];
            entry._prompt = parts[2];
            entry._entry = parts[3];
            newList.Add(entry);
        }

        return newList;
    }
}