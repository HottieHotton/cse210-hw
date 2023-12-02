// Program.cs
using System;

class Program
{
    static async Task Main()
    {
        string apiKey = "";
        string apiUrl = "https://api.easypost.com/v2/";

        Addresses address = new Addresses(apiKey, apiUrl);
        Parcels parcel = new Parcels(apiKey, apiUrl);
        Shipment shipment = new Shipment(apiKey, apiUrl);

        // Example: create address
        string toAddressResponse = await address.CreateAddressAsync("John Doe", "123 Main St", "Anytown", "CA", "12345", "US", "123-456-7890");
        Console.WriteLine($"To Address Response: {toAddressResponse}");

        // Example: create parcel
        string parcelResponse = await parcel.CreateParcelAsync(12, 6, 2, 2);
        Console.WriteLine($"Parcel Response: {parcelResponse}");

        // Example: create shipment
        string fromAddressJson = await address.CreateAddressAsync("John Doe", "123 Main St", "Anytown", "CA", "12345", "US", "123-456-7890");
        string shipmentResponse = await shipment.CreateShipmentAsync(toAddressResponse, fromAddressJson, parcelResponse);
        Console.WriteLine($"Shipment Response: {shipmentResponse}");
    }
}
