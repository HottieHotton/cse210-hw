using System.Threading.Tasks;

public class Shipment : EasyBase
{
    public Shipment(string apiKey, string apiUrl) : base(apiKey, apiUrl) { }

    public async Task<string> CreateShipmentAsync(string toAddressJson, string fromAddressJson, string parcelJson)
    {
        string shipmentJson = $@"
        {{
            ""shipment"": {{
                ""to_address"": {toAddressJson},
                ""from_address"": {fromAddressJson},
                ""parcel"": {parcelJson}
            }}
        }}";

        return await PostAsync("shipments", shipmentJson);
    }
}
