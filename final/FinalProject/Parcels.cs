using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Parcels : EasyBase
{
    protected string _length;
    protected string _width;
    protected string _height;
    protected string _weight;
    public Parcels() : base("parcels") {}

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Parcel Menu!\n");
        while(cont == true){
            Console.WriteLine("1. Create Parcel Object");
            Console.WriteLine("2. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-2):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    Console.WriteLine(await CreateParcelAsync());
                    break;
                case "2":
                    cont = false;
                    break;
                default:
                    Console.WriteLine("Incorrect option, try again!");
                    break;
            }
        }
    }

    public async Task<string> CreateParcelAsync()
    {
        Console.WriteLine("Please enter the length: ");
        _length = Console.ReadLine();
        Console.WriteLine("Please enter the width: ");
        _width = Console.ReadLine();
        Console.WriteLine("Please enter the height: ");
        _height = Console.ReadLine();
        Console.WriteLine("Please enter the weight(in oz): ");
        _weight = Console.ReadLine();
        var parcelObject = new
        {
            length= _length,
            width= _width,
            height= _height,
            weight= _weight
        };
        // Serialize the addressObject to JSON
        string parcelJson = JsonConvert.SerializeObject(parcelObject, Formatting.Indented);
        return await base.MakePostRequest(_apiEndpoint, parcelJson);
    }
}
