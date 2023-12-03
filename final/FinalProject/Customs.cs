using System.Threading.Tasks;

public class Customs : EasyBase
{
    public Customs() : base() { }

    public async override void Menu(string choice){
        
    }

    public async Task<string> CreateCustomsAsync()
    {
        string customsJson = $@"
        {{
            // Add customs details here
        }}";

        return await base.PostAsync("customs", customsJson);
    }
}