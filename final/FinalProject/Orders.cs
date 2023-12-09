using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Orders : EasyBase
{
    private List<object> shipmentsList;
    Addresses _address;
    Parcels _parcel;
    Customs _customs;
    private string _orderResponse;

    public Orders() : base("orders") {
        shipmentsList = new List<object>();
        _address = new Addresses();
        _parcel = new Parcels();
        _customs = new Customs();
    }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Orders Menu!(if you wish to buy an order, create one first.)");
        Console.WriteLine("This is due to the orders endpoint not having a retrieve all endpoint(it doesn't exist).");
        while(cont == true){
            Console.WriteLine("1. Create a Domestic Order(Multi-Parcel shipment)");
            Console.WriteLine("2. Buy an Order");
            Console.WriteLine("3. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-3):");
            choice = Console.ReadLine();
            
            switch(choice){
                case "1": 
                    _orderResponse = await CreateOrderAsync();
                    JToken orderJson = JToken.Parse(_orderResponse);
                    Console.WriteLine(orderJson);
                    break;
                case "2": 
                    string buyOrder = await BuyCall();
                    JToken buyOrderJson = JToken.Parse(buyOrder);

                    string trackingCode;
                    string trackingLink;
                    string postageLink;

                    int counter =1;

                    foreach (var shipmentLinks in buyOrderJson["shipments"]){
                        if (shipmentLinks["tracker"] != null && shipmentLinks["tracker"].Type != JTokenType.Null){
                            trackingCode = shipmentLinks["tracker"]["tracking_code"]?.ToString();
                            trackingLink = shipmentLinks["tracker"]["public_url"]?.ToString();
                            postageLink = shipmentLinks["postage_label"]["label_url"]?.ToString();
                            Console.WriteLine($"Tracking Code: {trackingCode}\nTracking Page: {trackingLink}\nLabel Link #{counter}: {postageLink}");
                        }else{
                            postageLink = shipmentLinks["postage_label"]["label_url"]?.ToString();
                            Console.WriteLine($"Label Link #{counter}: {postageLink}");
                        }
                        counter++;
                    };
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

    public async Task<string> CreateOrderAsync()
    {
        string choice = "";
        // to_address
        Console.WriteLine("\nPlease enter a desitionation address:\n");
        string toAddressJson = await _address.CreateAddressAsync();
        var toAddressResponse = JsonConvert.DeserializeObject(toAddressJson);

        // from_address
        Console.WriteLine("\nPlease enter a origin address:\n");
        string fromAddressJson = await _address.CreateAddressAsync();
        var fromAddressResponse = JsonConvert.DeserializeObject(fromAddressJson);
        // parcel
        while(choice != "q"){
            string parcelJson = await _parcel.CreateParcelAsync();
            var parcelResponse = JsonConvert.DeserializeObject(parcelJson);
            shipmentsList.Add(new { parcel = parcelResponse });
            Console.WriteLine("\nWould you like to add another package? Press enter if yes, press 'q' if you are done!");
            choice = Console.ReadLine();
        }
        //Creates body for the order create call
        var orderObject = new{
            order = new
                {
                    to_address = toAddressResponse,
                    from_address = fromAddressResponse,
                    shipments = shipmentsList
                }
        };

        string orderJson = JsonConvert.SerializeObject(orderObject, Formatting.Indented);
        return await base.MakePostRequest(_apiEndpoint, orderJson);
    }

    public async override Task<string> BuyCall(){
        Console.WriteLine("Grabbing Last Created Order...");
        JToken orderJson = JToken.Parse(_orderResponse);
        string orderId = orderJson["id"].ToString();
        HashSet<(string Service, string Carrier, string Price)> availableServicesAndCarriers = new HashSet<(string, string, string)>();

        foreach (var rate in orderJson.SelectTokens("shipments[*].rates[*]"))
        {
            if (rate != null)
            {
                string service = rate["service"]?.ToString();
                string carrier = rate["carrier"]?.ToString();
                string price = rate["rate"]?.ToString();

                if (!string.IsNullOrEmpty(service) && !string.IsNullOrEmpty(carrier) && !string.IsNullOrEmpty(price))
                {
                    availableServicesAndCarriers.Add((service, carrier, price));
                }
            }
        }

        // Display the available services and carriers
        int optionNumber = 1;
        Console.WriteLine("Available shipping services and carriers for the entire order:");
        foreach (var (service, carrier, price) in availableServicesAndCarriers)
            {
                Console.WriteLine($"{optionNumber}. Service: {service}, Carrier: {carrier}, Price: {price}");
                optionNumber++;
            }
        
        string selectedCarrier;
        string selectedService;
        do
        {
            Console.Write("Select an option (enter the number): ");
            int selectedRate;
            if (int.TryParse(Console.ReadLine(), out selectedRate) && selectedRate >= 1 && selectedRate <= availableServicesAndCarriers.Count)
            {
                // Get the selected service and carrier
                var selectedServiceAndCarrier = availableServicesAndCarriers.ElementAt(selectedRate - 1);
                selectedService = selectedServiceAndCarrier.Service;
                selectedCarrier = selectedServiceAndCarrier.Carrier;

                Console.WriteLine($"You selected Service: {selectedService}, Carrier: {selectedCarrier}");
                break; 
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        } while (true);

        var buyContent = new{
            carrier = selectedCarrier,
            service = selectedService
        };
        string buyJson = JsonConvert.SerializeObject(buyContent, Formatting.Indented);
        return await MakePostRequest(_apiEndpoint+$"/{orderId}/buy", buyJson);
    }
}