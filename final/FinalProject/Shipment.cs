using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            Console.WriteLine("\n1. Create Domestic Shipment");
            Console.WriteLine("2. Create International Shipment(US-Outbound)");
            Console.WriteLine("3. Retrieve a list of Shipments");
            Console.WriteLine("4. Purchase a Shipment");
            Console.WriteLine("5. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-5):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    var domestic = await CreateDomesticShipmentAsync();
                    JToken shipDomestic = JToken.Parse(domestic);
                    Console.WriteLine(shipDomestic);
                    break;
                case "2": 
                    var international = await CreateInternationalShipmentAsync();
                    JToken shipInternational = JToken.Parse(international);
                    Console.WriteLine(shipInternational);
                    break;
                case "3": 
                    Console.WriteLine("How many items would you like to display?");
                    int pageSize = int.Parse(Console.ReadLine());
                    string retrieveList = await RetrieveShipmentList($"{_apiEndpoint}", pageSize);
                    JToken formattedList = JToken.Parse(retrieveList);
                    Console.WriteLine(formattedList);
                    break;
                case "4": 
                    string buyResponse = await BuyCall();
                    if(buyResponse != "Try again!"){
                        JToken buyJson = JToken.Parse(buyResponse);
                        string trackingUrl = buyJson["tracker"]["public_url"].ToString();
                        base.OpenLink(trackingUrl);
                        string label = buyJson["postage_label"]["label_url"].ToString();
                        base.OpenLink(label);
                        if(buyJson["forms"] != null && buyJson["forms"].HasValues){
                            string invoice = buyJson["forms"]["form_url"].ToString();
                            base.OpenLink(invoice);
                        }
                    }
                    break;
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
        string toAddressJson = await _address.CreateAddressAsync();
        var toAddressResponse = JsonConvert.DeserializeObject(toAddressJson);

        // from_address
        Console.WriteLine("\nPlease enter a origin address:\n");
        string fromAddressJson = await _address.CreateAddressAsync();
        var fromAddressResponse = JsonConvert.DeserializeObject(fromAddressJson);

        // parcel
        Console.WriteLine("\nPlease enter the dimensions:\n");
        string parcelJson = await _parcel.CreateParcelAsync();
        var parcelResponse = JsonConvert.DeserializeObject(parcelJson);

        var shipmentObject = new
        {
            shipment = new {
                to_address= toAddressResponse,
                from_address = fromAddressResponse,
                parcel = parcelResponse
            }
        };
        string shipmentJson = JsonConvert.SerializeObject(shipmentObject, Formatting.Indented);
        return await base.MakePostRequest(_apiEndpoint, shipmentJson);
    }

    public async Task<string> CreateInternationalShipmentAsync()
    {
        // to_address
        Console.WriteLine("\nPlease enter a desitionation address:\n");
        var toAddressResponse = await _address.CreateAddressAsync();

        // from_address
        Console.WriteLine("\nPlease enter a origin address:\n");
        var fromAddressResponse = await _address.CreateAddressAsync();

        // parcel
        Console.WriteLine("\nPlease enter the dimensions:\n");
        var parcelResponse = await _parcel.CreateParcelAsync();

        // Customs
        Console.WriteLine("\nPlease enter your customs information:\n");
        var customsObject = await _customs.CreateCustomsAsync();

        //Creates shipment body for create call
        var shipmentObject = new
        {
            shipment = new {
                to_address= toAddressResponse,
                from_address = fromAddressResponse,
                parcel = parcelResponse,
                customs_info = customsObject
            }
        };
        string shipmentJson = JsonConvert.SerializeObject(shipmentObject, Formatting.Indented);
        return await base.MakePostRequest(_apiEndpoint, shipmentJson);
    }

    public async override Task<string> BuyCall(){
        //Uses the Retrieve Shipment method to display 5 recent shipments and their status
        Console.WriteLine("Please enter a shipment that you'd like to purchase: ");
        string retrieveList = await RetrieveShipmentList($"{_apiEndpoint}", 5);
        JToken shipmentList = JToken.Parse(retrieveList);
        foreach(var shipment in shipmentList["shipments"]){
            Console.WriteLine($"{shipment["id"]}: {shipment["status"]}");
        }
        Console.Write("Enter shipment ID: ");
        string selectedShipmentId = Console.ReadLine();

        //Takes the shipment ID andpulls the json to display rates
        string endpoint = $"{_apiEndpoint}/{selectedShipmentId}";
        string shipmentData = await MakeGetRequest(endpoint);
        JToken shipmentJson = JToken.Parse(shipmentData);
        if (shipmentJson["rates"] != null && shipmentJson["rates"].HasValues){
            Console.WriteLine("Select a rate to purchase:");
            // Display a list of rates
            foreach (var rate in shipmentJson["rates"]){
                Console.WriteLine($"{rate["id"]}: {rate["carrier"]}, {rate["service"]}, {rate["rate"]}");
            }
            Console.Write("Enter rate ID: ");
            string selectedRateId = Console.ReadLine();

            //Creates rate body for the buy call
            var buyContent = new{
                rate = new{
                    id = selectedRateId
                }
            };
            string buyJson = JsonConvert.SerializeObject(buyContent, Formatting.Indented);
            return await MakePostRequest(_apiEndpoint+$"/{selectedShipmentId}/buy", buyJson);
        }
        else
            {
                Console.WriteLine("No rates found for the selected shipment.. Errors are as follows:");
                foreach (var message in shipmentJson["messages"]){
                    string carrier = message["carrier"]?.ToString();
                    string errorMessage = message["message"]?.ToString();

                    if (!string.IsNullOrEmpty(carrier) && !string.IsNullOrEmpty(errorMessage)){
                        Console.WriteLine($"Error with {carrier}: {errorMessage}");
                    }
                }
                return "Try again!";
            }
    }
}
