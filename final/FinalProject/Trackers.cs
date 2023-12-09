using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

public class Trackers : EasyBase
{
    public Trackers() : base("trackers") { }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Trackers Menu!\n");
        while(cont == true){
            Console.WriteLine("1. Create Tracker");
            Console.WriteLine("2. Retrieve a list of Trackers");
            Console.WriteLine("3. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-3):");
            choice = Console.ReadLine();

            switch(choice){
                case "1":
                    string tracking= await CreateTrackerAsync();
                    JToken formattedJson = JToken.Parse(tracking);
                    Console.WriteLine(formattedJson);
                    Console.WriteLine("Opening Tracking Page...");
                    string url = formattedJson["public_url"].ToString();
                    base.OpenLink(url);
                    break;
                case "2": 
                    Console.WriteLine("How many items would you like to display?");
                    int pageSize = int.Parse(Console.ReadLine());
                    string retrieveList = await RetrieveList($"{_apiEndpoint}", pageSize);
                    JToken formattedList = JToken.Parse(retrieveList);
                    Console.WriteLine(formattedList);
                    break;
                case "3":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }

    public async Task<string> CreateTrackerAsync()
    {
        Console.WriteLine("Please enter a test tracking number(EZ1000000001..through...EZ7000000007 only): ");
        string trackingNum= Console.ReadLine();
        Console.WriteLine("Please enter a carrier(USPS, FedEx, UPS): ");
        string carrier = Console.ReadLine();
        string trackerJson = $@"
        {{
            ""tracking_code"": ""{trackingNum}"",
            ""carrier"": ""{carrier}""
        }}";

        string response = await base.MakePostRequest(_apiEndpoint, trackerJson);
        return response;
    }
}