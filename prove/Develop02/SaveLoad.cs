using System;
using System.IO;

class SaveLoad{
    public string _fileName;

    public void SaveFile(List<Entry> newList){
        using(StreamWriter outputFile = new StreamWriter(_fileName)){
            foreach(Entry entry in newList){
                outputFile.WriteLine(entry.AddLine());
            }
        }
        Console.WriteLine($"File Saved under the name {_fileName}");
    }
}