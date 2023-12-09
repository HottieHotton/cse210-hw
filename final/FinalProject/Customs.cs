using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

public class Customs : EasyBase
{
    protected string _signer;
    protected string _contentType;
    protected string _contentDetails;
    protected string _itemDesription;
    protected string _quantity;
    protected string _weight;
    protected string _value;
    protected string _tariffCode;
    protected string _origin;
    protected List<object> customsItems;

    public Customs() : base("customs_infos") {
        customsItems = new List<object>();
    }

    public async override Task Menu(){
        string choice;
        bool cont = true;
        Console.WriteLine("Welcome to the Customs Menu!\n");
        while(cont == true){
            Console.WriteLine("1. Create a Customs Object");
            Console.WriteLine("2. Return to Main Menu\n");
            Console.WriteLine("Please select one of the following options(1-2):");
            choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    string customs = await CreateStandAloneCustomsAsync();
                    JToken customsJson = JToken.Parse(customs);
                    Console.WriteLine(customsJson);
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

    public async Task<string> CreateStandAloneCustomsAsync()
    {
        string user = "";
        Console.WriteLine("Please enter the person who approves this customs information: ");
        _signer = Console.ReadLine();
        Console.WriteLine("Please enter the content type(ex. 'documents','merchandise', 'gift'): ");
        _contentType = Console.ReadLine();
        Console.WriteLine("Please enter what these contents are(clothes, tools, ect.): ");
        _contentDetails = Console.ReadLine();
        while(true){
            Console.WriteLine("Please enter the item description: ");
            _itemDesription = Console.ReadLine();
            Console.WriteLine("Please enter the quantity of this item: ");
            _quantity = Console.ReadLine();
            Console.WriteLine("Please enter the weight of this item(in oz): ");
            _weight = Console.ReadLine();
            Console.WriteLine("Please enter the value($) of the item: ");
            _value = Console.ReadLine();
            Console.WriteLine("Please enter the tariff code asossiated with this item(ex 620520 for mens cotton shirt): ");
            _tariffCode = Console.ReadLine();
            Console.WriteLine("Please enter the origin of the item(US, GB, CA, AU): ");
            _origin = Console.ReadLine();
            customsItems.Add(new
            {
                description = _itemDesription,
                quantity = _quantity,
                weight = _weight,
                value = _value,
                hs_tariff_number = _tariffCode,
                origin_country = _origin
            });

            Console.WriteLine("Do you want to add another item? Press Enter to continue, press 'q' to stop: ");
            user = Console.ReadLine();
            if(user.ToLower() == "q") break;
        }

        string _restriction = "none";
        string _eelPfc = "NOEEI 30.37(a)";
        var customsObject = new{
            customs_info = new{
                customs_certify= true,
                customs_signer = _signer,
                contents_type = _contentType,
                contents_explanation = _contentDetails,
                restriction_type = _restriction,
                eel_pfc = _eelPfc,
                customs_items = customsItems
            }
        };

        string customsJson = JsonConvert.SerializeObject(customsObject, Formatting.Indented);
        return await base.MakePostRequest(_apiEndpoint, customsJson);
    }

    public string CreateCustomsAsync()
    {
        string user = "";
        Console.WriteLine("Please enter the person who approves this customs information: ");
        _signer = Console.ReadLine();
        Console.WriteLine("Please enter the content type(ex. 'documents','merchandise', 'gift'): ");
        _contentType = Console.ReadLine();
        Console.WriteLine("Please enter what these contents are(clothes, tools, ect.): ");
        _contentDetails = Console.ReadLine();
        while(true){
            Console.WriteLine("Please enter the item description: ");
            _itemDesription = Console.ReadLine();
            Console.WriteLine("Please enter the quantity of this item: ");
            _quantity = Console.ReadLine();
            Console.WriteLine("Please enter the weight of this item: ");
            _weight = Console.ReadLine();
            Console.WriteLine("Please enter the value($) of the item: ");
            _value = Console.ReadLine();
            Console.WriteLine("Please enter the tariff code asossiated with this item(ex 620520 for mens cotton shirt): ");
            _tariffCode = Console.ReadLine();
            Console.WriteLine("Please enter the origin of the item(US, GB, CA, AU): ");
            _origin = Console.ReadLine();
            customsItems.Add(new
            {
                description = _itemDesription,
                quantity = _quantity,
                weight = _weight,
                value = _value,
                hs_tariff_number = _tariffCode,
                origin_country = _origin
            });

            Console.WriteLine("Do you want to add another item? Press Enter to continue, press 'q' to stop: ");
            user = Console.ReadLine();
            if(user.ToLower() == "q") break;
        }

        string _restriction = "none";
        string _eelPfc = "NOEEI 30.37(a)";
        var customsObject = new{
            customs_info = new{
                customs_certify= true,
                customs_signer = _signer,
                contents_type = _contentType,
                contents_explanation = _contentDetails,
                restriction_type = _restriction,
                eel_pfc = _eelPfc,
                customs_items = customsItems
            }
        };

        string customsJson = JsonConvert.SerializeObject(customsObject, Formatting.Indented);
        return customsJson;
    }
}