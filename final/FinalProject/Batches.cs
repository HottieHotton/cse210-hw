using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Batches : EasyBase
{
    private List<object> shipmentsList;
    Shipment _shipment;
    string _getShipment;
    JToken _format;
    public Batches() : base("batches") {
        shipmentsList = new List<object>();
        _shipment = new Shipment();
    }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Batches Menu!\n");
        while(cont == true){
            Console.WriteLine("\n1. Create Batch");
            Console.WriteLine("2. Add a Shipment to a Batch");
            Console.WriteLine("3. Remove a Shipment from a Batch");
            Console.WriteLine("4. Retrieve a List of Batches");
            Console.WriteLine("5. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-6):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    var batch = await CreateBatchAsync();
                    _format = JToken.Parse(batch);
                    Console.WriteLine(_format);
                    break;
                case "2": 
                    string add = await AddShipment();
                    _format = JToken.Parse(add);
                    Console.WriteLine(_format);
                    break;
                case "3": 
                    string remove = await RemoveShipment();
                    _format = JToken.Parse(remove);
                    Console.WriteLine(_format);
                    break;
                case "4":
                    Console.WriteLine("How many items would you like to display?");
                    int pageSize = int.Parse(Console.ReadLine());
                    string retrieveList = await RetrieveList($"{_apiEndpoint}", pageSize);
                    JToken formattedList = JToken.Parse(retrieveList);
                    Console.WriteLine(formattedList);
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

    public async Task<string> CreateBatchAsync()
    {
        string option;

        while(true){
            Console.WriteLine("Would you like to create a domestic(1) or international shipment(2)? Press 'q' to stop: ");
            option = Console.ReadLine();
            if(option == "1"){
                _getShipment = await _shipment.CreateDomesticShipmentAsync();
                _format = JToken.Parse(_getShipment);
                shipmentsList.Add( new {id = _format["id"].ToString()});
            }else if(option == "2"){
                _getShipment = await _shipment.CreateInternationalShipmentAsync();
                _format = JToken.Parse(_getShipment);
                shipmentsList.Add( new {id = _format["id"].ToString()});
            }else if(option == "q"){
                Console.WriteLine("Creating batch...");
                break;
            }else{
                Console.WriteLine("Incorrect Option, try again!");
            }
        }
        var batchObject = new{
            batch = new{
                shipments = shipmentsList
            }
        };

        string batchJson = JsonConvert.SerializeObject(batchObject, Formatting.Indented);
        return await base.MakePostRequest(_apiEndpoint, batchJson);
    }

    public async Task<string> AddShipment(){
        Console.WriteLine("Please enter a batch that you'd like to edit: ");
        string retrieveList = await RetrieveShipmentList($"{_apiEndpoint}", 5);
        JToken batchList = JToken.Parse(retrieveList);
        foreach(var batch in batchList["batches"]){
            Console.WriteLine($"{batch["id"]}: {batch["num_shipments"]} shipments");
        }
        Console.Write("Enter batch ID: ");
        string selectedBatchId = Console.ReadLine();
        string endpoint = $"{_apiEndpoint}/{selectedBatchId}";
        string batchData = await MakeGetRequest(endpoint);
        JToken batchJson = JToken.Parse(batchData);

        string option;
        string shipID = "";
        do
        {
            Console.WriteLine("Would you like to add a domestic(1) or international shipment(2)?");
            option = Console.ReadLine();
                if(option == "1"){
                    _getShipment = await _shipment.CreateDomesticShipmentAsync();
                    _format = JToken.Parse(_getShipment);
                    shipID = _format["id"].ToString();
                    break;
                }else if(option == "2"){
                    _getShipment = await _shipment.CreateInternationalShipmentAsync();
                    _format = JToken.Parse(_getShipment);
                    shipID = _format["id"].ToString();
                    break;
                }else{
                    Console.WriteLine("Incorrect Option, try again!");
                }
        } while (true);

        var addID = new {
            shipments = new[]{
                new {id = shipID}
            }
        };
        
        string addJson = JsonConvert.SerializeObject(addID, Formatting.Indented);
        return await base.MakePostRequest($"{_apiEndpoint}/{selectedBatchId}/add_shipments", addJson);
    }

    public async Task<string> RemoveShipment(){
        Console.WriteLine("Please enter a batch that you'd like to edit: ");
        string retrieveList = await RetrieveShipmentList($"{_apiEndpoint}", 5);
        JToken batchList = JToken.Parse(retrieveList);
        foreach(var batch in batchList["batches"]){
            Console.WriteLine($"{batch["id"]}: {batch["num_shipments"]} shipments");
        }
        Console.Write("Enter batch ID: ");
        string selectedBatchId = Console.ReadLine();
        string endpoint = $"{_apiEndpoint}/{selectedBatchId}";
        string batchData = await MakeGetRequest(endpoint);
        JToken batchJson = JToken.Parse(batchData);

        string select = "";
        //Display shipment ids within batch
        foreach (var shipment in batchJson["shipments"]){
            Console.WriteLine($"ID: {shipment["id"]}");
        }
        Console.WriteLine("\nPlease enter the shipment ID you'd like to remove: ");
        select = Console.ReadLine();
        var removeID = new {
            shipments = new[]{
                new {id = select}
            }
        };
        
        string removeJson = JsonConvert.SerializeObject(removeID, Formatting.Indented);
        return await base.MakePostRequest($"{_apiEndpoint}/{selectedBatchId}/remove_shipments", removeJson);
    }
}