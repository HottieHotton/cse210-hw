using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Orders : EasyBase
{
    public Orders() : base("orders/") { }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Orders Menu!");
        while(cont == true){
            Console.WriteLine("1. Create a Order(Multi-Parcel shipment)");
            Console.WriteLine("2. Buy an Order");
            Console.WriteLine("3. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-3):");
            choice = Console.ReadLine();
            
            switch(choice){
                case "1": break;
                case "2": break;
                case "3":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }

    public async Task<string> CreateOrderAsync()
    {
        string orderJson = $@"
        {{
            // Add order details here
        }}";

        return await base.MakePostRequest(_apiEndpoint, orderJson);
    }
}