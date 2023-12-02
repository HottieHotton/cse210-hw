using System.Threading.Tasks;

public class Addresses : EasyBase
{
    public Addresses(string apiKey, string apiUrl) : base(apiKey, apiUrl) { }

    public async Task<string> CreateAddressAsync(string name, string street, string city, string state, string zip, string country, string phone)
    {
        string addressJson = $@"
        {{
            ""name"": ""{name}"",
            ""street1"": ""{street}"",
            ""city"": ""{city}"",
            ""state"": ""{state}"",
            ""zip"": ""{zip}"",
            ""country"": ""{country}"",
            ""phone"": ""{phone}""
        }}";

        return await PostAsync("addresses", addressJson);
    }
}