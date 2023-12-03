using System.Net.Http;
using System.Threading.Tasks;

public abstract class EasyBase
{
    protected string _apiKey;
    protected string _apiUrl;

    public EasyBase(){}

    protected async Task<string> PostAsync(string endpoint, string jsonContent)
    {
        using (HttpClient client = new HttpClient())
        {
            _apiKey = "";
            _apiUrl = "https://api.easypost.com/v2/";
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(_apiUrl + endpoint, content);

            // Read the response content
            return await response.Content.ReadAsStringAsync();
        }
    }

    protected async Task<string> RetrieveList(string endpoint, int pageSize){
        string retrieveContent = "1";
        return await PostAsync(endpoint, retrieveContent);
    }

    public async virtual void Menu(string choice){
        
    }

    protected async Task<string> BuyCall(string endpoint, string buyContent){
        buyContent = "1";
        return await PostAsync(endpoint, buyContent);
    }
}