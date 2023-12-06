using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Parcels : EasyBase
{
    protected double _length;
    protected double _width;
    protected double _height;
    protected double _weight;
    protected string _predefined_package;

    public Parcels() : base("parcels/") {}

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
                case "1": break;
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
        _length = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Please enter the width: ");
        _width = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Please enter the height: ");
        _height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Please enter the weight(in oz): ");
        _weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(_weight);
        Console.WriteLine("Please enter a predefined_package(press enter to leave empty): ");
        _predefined_package = Console.ReadLine();
        string parcelJson = $@"
        {{
            ""length"": ""{_length}"",
            ""width"": ""{_width}"",
            ""height"": ""{_height}"",
            ""weight"": ""{_weight}""
        }}";

        return await base.MakePostRequest(_apiEndpoint, parcelJson);
    }
}
