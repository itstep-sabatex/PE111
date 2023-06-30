using System.Net.Http.Json;
using System.Text.Json;

namespace ExchangeDemo
{
    internal class Program
    {
        static readonly HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://sabatex.francecentral.cloudapp.azure.com/")
            
        };
        static async Task Main(string[] args)
        {
            var clientId = "";
            var password = "";
            var login = new { clientId = clientId, password = password };
            var response = await httpClient.PostAsJsonAsync("api/v0/login", login);
            if (response != null)
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<Token>();
                    httpClient.DefaultRequestHeaders.Add("clientId", clientId);
                    httpClient.DefaultRequestHeaders.Add("apiToken", result.AccessToken);
                    httpClient.DefaultRequestHeaders.Add("destinationId", "9b559f65-5ad1-4147-a6c0-7b7a6d44c2d2");
                    var data = new
                    {
                        objectType = "trey", // max 50
                        objectId = Guid.NewGuid().ToString(),   // max 50
                        text = "Hello world",        // unlimited (system limit)
                        dateStamp = DateTime.Now
                    };
                    response = await httpClient.PostAsJsonAsync("api/v0/objects", data);
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {


                        }
                        else
                        {
                            string s = await response.Content.ReadAsStringAsync();
                        }
                    }

                    var resul = await httpClient.GetFromJsonAsync<ObjectExchange[]>("api/v0/objects");
                    if (resul == null) return;
                    foreach (var item in resul)
                    {
                        await httpClient.DeleteAsync($"api/v0/objects/{item.Id}");
                    }
                    

                }


                    }
            else { }
            Console.WriteLine("Hello, World!");
            var c =ApiConnector.Login(new Uri("https://sabatex.francecentral.cloudapp.azure.com/"), new Guid(""), "");
        }
    }
}