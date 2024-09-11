using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace UnityAnalytics.Front.Controllers;

public class ControllerBase : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public ControllerBase(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
      
    }

    private HttpClient CreateClient()
    {
        return _clientFactory.CreateClient();
    }

    protected async Task<HttpResponseMessage> PostAsync<T>(string url, T model)
    {
        var client = CreateClient();
        var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        Console.WriteLine("W"+await content.ReadAsStringAsync());
        var response = await client.PostAsync(url, content);
        return response;
    }
    protected async Task<T?> DeserializeResponseAsync<T>(HttpResponseMessage response)
    {
        var jsonData = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(jsonData))
        {
            return default;
        }

        try
        {
            return JsonSerializer.Deserialize<T>(jsonData,new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
        catch (JsonException ex)
        {
            // Log the exception details
            return default;
        }
    }
    

 
}

