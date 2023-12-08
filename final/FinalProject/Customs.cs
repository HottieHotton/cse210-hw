using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Customs : EasyBase
{
    public Customs() : base("customs_infos") { }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Customs Menu!\n");
        while(cont == true){
            Console.WriteLine("1. Create a Customs Object");
            Console.WriteLine("2. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-2):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": break;
                case "2":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }

    public async Task<string> CreateStandAloneCustomsAsync()
    {
        string customsJson = $@"
        {{
            // Add customs details here
        }}";

        return await base.MakePostRequest(_apiEndpoint, customsJson);
    }

    public string CreateCustomsAsync()
    {
        string customsJson = $@"
        {{
            // Add customs details here
        }}";

        return customsJson;
    }
}