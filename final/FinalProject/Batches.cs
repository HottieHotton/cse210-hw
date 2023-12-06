using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Batches : EasyBase
{
    public Batches() : base("batches/") { }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Batches Menu!\n");
        while(cont == true){
            Console.WriteLine("1. Create Batch");
            Console.WriteLine("2. Add a Shipment to a Batch");
            Console.WriteLine("3. Remove a Shipment from a Batch");
            Console.WriteLine("4. Purchase Batch");
            Console.WriteLine("5. Retrieve a List of Batches");
            Console.WriteLine("6. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-6):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": break;
                case "2": break;
                case "3": break;
                case "4": break;
                case "5": break;
                case "6":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }

    public async Task<string> CreateBatchAsync()
    {
        string batchJson = $@"
        {{
            // Add batch details here
        }}";

        return await base.MakePostRequest(_apiEndpoint, batchJson);
    }
}