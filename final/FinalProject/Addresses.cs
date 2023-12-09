using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Addresses : EasyBase
{
    protected string _name;
    protected string _street;
    protected string _city;
    protected string _state;
    protected string _zip;
    protected string _country;
    protected string _phone;

    public Addresses() : base("addresses") { }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Address Menu!\n");
        while(cont == true){
            Console.WriteLine("1. Create Address");
            Console.WriteLine("2. Create and Verify an Address");
            Console.WriteLine("3. Retrieve a list of Addresses");
            Console.WriteLine("4. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-4):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    Console.WriteLine(await CreateAddressAsync());
                    break;
                case "2": 
                    Console.WriteLine(await CreateAndVerifyAddressAsync());
                    break;
                case "3": 
                    Console.WriteLine("How many items would you like to display?");
                    int pageSize = int.Parse(Console.ReadLine());
                    string retrieveList = await RetrieveList($"{_apiEndpoint}", pageSize);
                    JToken formattedList = JToken.Parse(retrieveList);
                    Console.WriteLine(formattedList);
                    break;
                case "4":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }

    public async Task<string> CreateAddressAsync()
    {
        Console.WriteLine("Please enter the name: ");
        _name = Console.ReadLine();
        Console.WriteLine("Please enter the street address: ");
        _street = Console.ReadLine();
        Console.WriteLine("Please enter the city: ");
        _city = Console.ReadLine();
        Console.WriteLine("Please enter the state: ");
        _state = Console.ReadLine();
        Console.WriteLine("Please enter the zip code: ");
        _zip = Console.ReadLine();
        Console.WriteLine("Please enter the country(ISO Code(like US and GB)): ");
        _country = Console.ReadLine();
        Console.WriteLine("Please enter the phone number: ");
        _phone = Console.ReadLine();
        var addressObject = new
        {
            name= _name,
            street1= _street,
            city= _city,
            state= _state,
            zip= _zip,
            country= _country,
            phone= _phone
        };
            // Serialize the addressObject to JSON
        string addressJson = JsonConvert.SerializeObject(addressObject, Formatting.Indented);
        return await base.MakePostRequest(_apiEndpoint, addressJson);
    }

    public async Task<string> CreateAndVerifyAddressAsync()
    {
        Console.WriteLine("Please enter the name: ");
        _name = Console.ReadLine();
        Console.WriteLine("Please enter the street address: ");
        _street = Console.ReadLine();
        Console.WriteLine("Please enter the city: ");
        _city = Console.ReadLine();
        Console.WriteLine("Please enter the state: ");
        _state = Console.ReadLine();
        Console.WriteLine("Please enter the zip code: ");
        _zip = Console.ReadLine();
        Console.WriteLine("Please enter the country(ISO Code(like US and GB)): ");
        _country = Console.ReadLine();
        Console.WriteLine("Please enter the phone number: ");
        _phone = Console.ReadLine();
        var addressObject = new
        {
            name= _name,
            street1= _street,
            city= _city,
            state= _state,
            zip= _zip,
            country= _country,
            phone= _phone
        };
            // Serialize the addressObject to JSON
        string addressJson = JsonConvert.SerializeObject(addressObject, Formatting.Indented);
        return await base.MakePostRequest($"{_apiEndpoint}/create_and_verify", addressJson);
    }
}