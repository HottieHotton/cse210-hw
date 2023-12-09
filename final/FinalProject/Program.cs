// Program.cs
using System;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        string menu;
        bool cont = true;
        Addresses address = new Addresses();
        Parcels parcel = new Parcels();
        Shipment shipment = new Shipment();
        Customs customs = new Customs();
        Orders orders = new Orders();
        Batches batches = new Batches();
        Trackers trackers = new Trackers();

        Console.WriteLine("Welcome to the EasyPost API!");
        while(cont == true){
            Console.WriteLine("Please select a endpoint(1-8):");
            Console.WriteLine("1. Addresses");
            Console.WriteLine("2. Parcels");
            Console.WriteLine("3. Shipments");
            Console.WriteLine("4. Customs");
            Console.WriteLine("5. Orders");
            Console.WriteLine("6. Batches");
            Console.WriteLine("7. Trackers");
            Console.WriteLine("8. Quit\n");
            Console.WriteLine("You select: ");
            menu = Console.ReadLine();

            switch(menu){
                case "1": 
                    await address.Menu();
                    break;
                case "2": 
                    await parcel.Menu();
                    break;
                case "3": 
                    await shipment.Menu();
                    break;
                case "4": 
                    await customs.Menu();
                    break;
                case "5": 
                    await orders.Menu();
                    break;
                case "6": 
                    await batches.Menu();
                    break;
                case "7": 
                    await trackers.Menu();
                    break;
                case "8":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }
}
