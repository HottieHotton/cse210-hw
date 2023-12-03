using System.Threading.Tasks;

public class Addresses : EasyBase
{
    protected string _name;
    protected string _street;
    protected string _city;
    protected string _state;
    protected string _zip;
    protected string _country;
    protected string _phone;

    public Addresses() : base() { }

    public async override void Menu(string choice){
        
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
        string addressJson = $@"
        {{
            ""name"": ""{_name}"",
            ""street1"": ""{_street}"",
            ""city"": ""{_city}"",
            ""state"": ""{_state}"",
            ""zip"": ""{_zip}"",
            ""country"": ""{_country}"",
            ""phone"": ""{_phone}""
        }}";

        return await base.PostAsync("addresses", addressJson);
    }
}