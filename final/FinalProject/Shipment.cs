using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Shipment : EasyBase
{
    Addresses _address;
    Parcels _parcel;
    Customs _customs;

    public Shipment() : base("shipments") {
        _address = new Addresses();
        _parcel = new Parcels();
        _customs = new Customs();
     }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Shipment Menu!\n");
        while(cont == true){
            Console.WriteLine("1. Create Domestic Shipment");
            Console.WriteLine("2. Create International Shipment");
            Console.WriteLine("3. Retrieve a list of Shipments");
            Console.WriteLine("4. Purchase a Shipment");
            Console.WriteLine("5. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-5):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    string domestic = await CreateDomesticShipmentAsync();
                    JToken shipDomestic = JToken.Parse(domestic);
                    Console.WriteLine(shipDomestic);
                    break;
                case "2": 
                    string international = await CreateInternationalShipmentAsync();
                    JToken shipInternational = JToken.Parse(international);
                    Console.WriteLine(shipInternational);
                    break;
                case "3": 
                    Console.WriteLine("How many items would you like to display?");
                    int pageSize = int.Parse(Console.ReadLine());
                    string retrieveList = await RetrieveList($"{_apiEndpoint}", pageSize);
                    JToken formattedList = JToken.Parse(retrieveList);
                    Console.WriteLine(formattedList);
                    break;
                case "4": break;
                case "5":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }

    public async Task<string> CreateDomesticShipmentAsync()
    {
        // to_address
        Console.WriteLine("\nPlease enter a desitionation address:\n");
        string toAddressResponse = await _address.CreateAddressAsync();

        // from_address
        Console.WriteLine("\nPlease enter a origin address:\n");
        string fromAddressResponse = await _address.CreateAddressAsync();

        // parcel
        Console.WriteLine("\nPlease enter the dimensions:\n");
        string parcelResponse = await _parcel.CreateParcelAsync();

        string shipmentJson = $@"
        {{
            ""shipment"": {{
                ""to_address"": {toAddressResponse},
                ""from_address"": {fromAddressResponse},
                ""_parcel"": {parcelResponse}
            }}
        }}";

        return await base.MakePostRequest(_apiEndpoint, shipmentJson);
    }

    public async Task<string> CreateInternationalShipmentAsync()
    {
        // to_address
        Console.WriteLine("\nPlease enter a desitionation address:\n");
        string toAddressResponse = await _address.CreateAddressAsync();

        // from_address
        Console.WriteLine("\nPlease enter a origin address:\n");
        string fromAddressResponse = await _address.CreateAddressAsync();

        // parcel
        Console.WriteLine("\nPlease enter the dimensions:\n");
        string parcelResponse = await _parcel.CreateParcelAsync();

        // Customs
        Console.WriteLine("\nPlease enter your customs information:\n");
        string customsJson = await _customs.CreateCustomsAsync();
        string shipmentJson = $@"
        {{
            ""shipment"": {{
                ""to_address"": {toAddressResponse},
                ""from_address"": {fromAddressResponse},
                ""_parcel"": {parcelResponse},
                ""customs_info"": {customsJson}
            }}
        }}";

        return await base.MakePostRequest(_apiEndpoint, shipmentJson);
    }
}
