using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

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
                    Console.WriteLine(tracking);
                    break;
                case "2": 
                    Console.WriteLine("How many items would you like to display?");
                    int pageSize = int.Parse(Console.ReadLine());
                    string retrieveList = await RetrieveList($"{_apiEndpoint}", pageSize);
                    JToken formattedJson = JToken.Parse(retrieveList);

                    Console.WriteLine(formattedJson);
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
        string trackerJson = $@"
        {{
            ""tracking_code"": ""EZ1000000002"",
            ""carrier"": ""USPS""
        }}";

        string response = await base.MakePostRequest(_apiEndpoint, trackerJson);
        return response;
    }
}