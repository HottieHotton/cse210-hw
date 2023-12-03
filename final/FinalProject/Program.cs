// Program.cs
using System;

class Program
{
    static async Task Main()
    {
        Addresses address = new Addresses();
        Parcels parcel = new Parcels();
        Shipment shipment = new Shipment();

        //Having this as is to confirm code is still working
        //Have retrieve call in EasyBase
        //Decide where to have Menu

        // to_address
        Console.WriteLine("Please enter a desitionation address:\n");
        string toAddressResponse = await address.CreateAddressAsync();

        // from_address
        Console.WriteLine("Please enter a origin address:\n");
        string fromAddressJson = await address.CreateAddressAsync();

        // parcel
        Console.WriteLine("Please enter the dimensions:\n");
        string parcelResponse = await parcel.CreateParcelAsync();

        // Example: create shipment
        string shipmentResponse = await shipment.CreateShipmentAsync(toAddressResponse, fromAddressJson, parcelResponse);
        Console.WriteLine($"Shipment Response: {shipmentResponse}");
    }
}
