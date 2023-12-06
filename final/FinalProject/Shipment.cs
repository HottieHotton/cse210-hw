using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Shipment : EasyBase
{
    public Shipment() : base("shipments/") { }

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
                case "1": break;
                case "2": break;
                case "3": break;
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

    public async Task<string> CreateDomesticShipmentAsync(string toAddressJson, string fromAddressJson, string parcelJson)
    {
        string shipmentJson = $@"
        {{
            ""shipment"": {{
                ""to_address"": {toAddressJson},
                ""from_address"": {fromAddressJson},
                ""parcel"": {parcelJson}
            }}
        }}";

        return await base.MakePostRequest(_apiEndpoint, shipmentJson);
    }

    public async Task<string> CreateInternationalShipmentAsync(string toAddressJson, string fromAddressJson, string parcelJson, string customsJson)
    {
        string shipmentJson = $@"
        {{
            ""shipment"": {{
                ""to_address"": {toAddressJson},
                ""from_address"": {fromAddressJson},
                ""parcel"": {parcelJson},
                ""customs_info"": {customsJson}
            }}
        }}";

        return await base.MakePostRequest(_apiEndpoint, shipmentJson);
    }
}
