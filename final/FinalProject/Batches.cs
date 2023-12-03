using System.Threading.Tasks;

public class Batches : EasyBase
{
    public Batches() : base() { }

    public async override void Menu(string choice){
        
    }

    public async Task<string> CreateBatchAsync()
    {
        string batchJson = $@"
        {{
            // Add batch details here
        }}";

        return await base.PostAsync("batches", batchJson);
    }
}