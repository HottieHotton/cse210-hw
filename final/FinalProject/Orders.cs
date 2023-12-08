using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Orders : EasyBase
{
    private List<object> shipmentsList;
    Addresses _address;
    Parcels _parcel;
    Customs _customs;

    public Orders() : base("orders") {
        shipmentsList = new List<object>();
        _address = new Addresses();
        _parcel = new Parcels();
        _customs = new Customs();
    }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Orders Menu!");
        while(cont == true){
            Console.WriteLine("1. Create a Domestic Order(Multi-Parcel shipment)");
            Console.WriteLine("2. Buy an Order");
            Console.WriteLine("3. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-3):");
            choice = Console.ReadLine();
            
            switch(choice){
                case "1": 
                    string orderResponse = await CreateOrderAsync();
                    JToken orderJson = JToken.Parse(orderResponse);
                    Console.WriteLine(orderJson);
                    break;
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
        string choice = "";
        // to_address
        Console.WriteLine("\nPlease enter a desitionation address:\n");
        string toAddressJson = _address.CreateAddressAsync();
        var toAddressResponse = JsonConvert.DeserializeObject(toAddressJson);

        // from_address
        Console.WriteLine("\nPlease enter a origin address:\n");
        string fromAddressJson = _address.CreateAddressAsync();
        var fromAddressResponse = JsonConvert.DeserializeObject(fromAddressJson);
        // parcel
        while(choice != "q"){
            string parcelJson = _parcel.CreateParcelAsync();
            var parcelResponse = JsonConvert.DeserializeObject(parcelJson);
            shipmentsList.Add(new { parcel = parcelResponse });
            Console.WriteLine("\nWould you like to add another package? Press enter if yes, press 'q' if you are done!");
            choice = Console.ReadLine();
        }
        var orderObject = new{
            order = new
                {
                    to_address = toAddressResponse,
                    from_address = fromAddressResponse,
                    shipments = shipmentsList
                }
        };

        string orderJson = JsonConvert.SerializeObject(orderObject, Formatting.Indented);
        Console.WriteLine(orderJson);
        return await base.MakePostRequest(_apiEndpoint, orderJson);
    }
}