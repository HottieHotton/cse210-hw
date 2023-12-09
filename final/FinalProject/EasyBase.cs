using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

public abstract class EasyBase
{
    protected string _apiKey;
    protected string _apiUrlBase;
    protected string _apiEndpoint;

    public EasyBase(string apiEndpoint){
        this._apiEndpoint = apiEndpoint;
        _apiKey = "";
        _apiUrlBase = "https://api.easypost.com/v2/";
    }

    //Sending POST requests to the API
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

    //Sending GET requests to the API
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

    //This is for items like Addresses and Trackers
    protected async Task<string> RetrieveList(string endpoint, int pageSize){
        endpoint = $"{endpoint}?page_size={pageSize}";
        return await MakeGetRequest(endpoint);
    }

    //This is for Shipments and Batches
    protected async Task<string> RetrieveShipmentList(string endpoint, int pageSize){
        endpoint = $"{endpoint}?page_size={pageSize}&purchased=false";
        return await MakeGetRequest(endpoint);
    }

    //Menu Virtual Method
    public async virtual Task Menu(){
        Console.WriteLine("Welcome to the Menu");
        await Task.CompletedTask;
    }

    //BuyCall Virtual Method
    public async virtual Task BuyCall(){
        Console.WriteLine("This is the buy call task");
        await Task.CompletedTask;
    }

    //Base method for opening links in Shipment.cs
    public void OpenLink(string url){
        Process.Start(new ProcessStartInfo {FileName = url, UseShellExecute = true});
    }
}
