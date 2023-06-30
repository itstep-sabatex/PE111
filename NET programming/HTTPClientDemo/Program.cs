using System.Xml;

namespace HTTPClientDemo
{
    internal class Program
    {
        static readonly HttpClient httpClient = new HttpClient() 
        {
            //BaseAddress = new Uri("https://www.google.com")
        };
        static async Task Main(string[] args)
        {
            try
            {
                //httpClient.DefaultRequestHeaders.Add("MyHeader", "Hello Google");
                //httpClient.BaseAddress = new Uri("https://www.google.com/");
                //HttpResponseMessage response = await httpClient.GetAsync("/");

                //string responseText = await response.Content.ReadAsStringAsync();
                HttpResponseMessage response = await httpClient.GetAsync("https://github.com/");
                string responseText = await response.Content.ReadAsStringAsync();
                string c = "> <div &qt &lt XmlDict </div>";
            } 
            
            catch { }

            Console.WriteLine("Hello, World!");
        }
    }
}