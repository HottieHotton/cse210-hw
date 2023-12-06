using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public abstract class EasyBase
{
    protected string _apiKey;
    protected string _apiUrlBase;
    protected string _apiEndpoint;

    public EasyBase(string apiEndpoint){
        this._apiEndpoint = apiEndpoint;
        _apiKey = "EZTK160a0df591e244fea75fa46f3d48b799Nr1sgXkxiUutTD0YP1S0Zw";
        _apiUrlBase = "https://api.easypost.com/v2/";
    }

    protected async Task<string> MakePostRequest(string endpoint, string jsonContent)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(_apiUrlBase + endpoint, content);
            
            // Read the response content
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }

    protected async Task<string> MakeGetRequest(string endpoint)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            HttpResponseMessage response = await client.GetAsync(_apiUrlBase + endpoint);
            
            // Read the response content
            string responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }

    protected async Task<string> RetrieveList(string endpoint, int pageSize){
        endpoint = $"{endpoint}?page_size={pageSize}";
        return await MakeGetRequest(endpoint);
    }

    public async virtual Task Menu(){
        Console.WriteLine("Welcome to the Menu");
        await Task.CompletedTask;
    }

    protected async Task<string> BuyCall(string endpoint, string buyContent){
        buyContent = "1";
        return await MakePostRequest(endpoint, buyContent);
    }
}