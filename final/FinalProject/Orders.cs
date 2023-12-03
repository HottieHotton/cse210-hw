using System.Threading.Tasks;

public class Orders : EasyBase
{
    public Orders() : base() { }

    public async override void Menu(string choice){
        
    }

    public async Task<string> CreateOrderAsync()
    {
        string orderJson = $@"
        {{
            // Add order details here
        }}";

        return await base.PostAsync("orders", orderJson);
    }
}