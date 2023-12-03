using System.Threading.Tasks;

public class Parcels : EasyBase
{
    protected double _length;
    protected double _width;
    protected double _height;
    protected double _weight;
    protected string _predefined_package;

    public Parcels() : base() {}

    public async override void Menu(string choice){
        
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

        return await base.PostAsync("parcels", parcelJson);
    }
}
