using System.Net.Http;
using System.Threading.Tasks;

public abstract class EasyBase
{
    protected string apiKey;
    protected string apiUrl;

    public EasyBase(string apiKey, string apiUrl)
    {
        this.apiKey = apiKey;
        this.apiUrl = apiUrl;
    }

    protected async Task<string> PostAsync(string endpoint, string jsonContent)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(apiUrl + endpoint, content);

            // Read the response content
            return await response.Content.ReadAsStringAsync();
        }
    }
}