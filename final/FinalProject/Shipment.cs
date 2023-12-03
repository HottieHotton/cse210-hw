using System.Threading.Tasks;

public class Shipment : EasyBase
{
    public Shipment() : base() { }

    public async override void Menu(string choice){
        
    }

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

        return await base.PostAsync("shipments", shipmentJson);
    }
}
