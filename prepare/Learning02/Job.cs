using System;

public class Job
{
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    public void Display(){
        Console.WriteLine($"{_jobTitle}\n{_company}\n{_startYear}-{_endYear}");
    }
}