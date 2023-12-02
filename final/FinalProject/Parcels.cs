using System.Threading.Tasks;

public class Parcels : EasyBase
{
    public Parcels(string apiKey, string apiUrl) : base(apiKey, apiUrl) { }

    public async Task<string> CreateParcelAsync(double length, double width, double height, double weight)
    {
        string parcelJson = $@"
        {{
            ""length"": {length},
            ""width"": {width},
            ""height"": {height},
            ""weight"": {weight}
        }}";

        return await PostAsync("parcels", parcelJson);
    }
}
