using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeDemo
{
    public class Token2
    {
        public string access_token { get; set; } = string.Empty;
        public string token_type { get; set; } = "Bearer";
        public string refresh_token { get; set; } = string.Empty;
        public int expires_in { get; set; }

    }
    internal class ApiConnector
    {
        static private Token2 _token = null;

        private readonly Guid clientId;
        private readonly string token;
        private readonly Uri host;
        private ApiConnector(Uri host, Guid clientId, string token)
        {
            this.host = host;
            this.clientId = clientId;
            this.token = token;
        }
        /// <summary>
        /// Login to service
        /// </summary>
        /// <param name="host"></param>
        /// <param name="clientId"></param>
        /// <param name="password"></param>
        /// <returns>return API instance or null is fail</returns>
        public static ApiConnector Login(Uri host, Guid clientId, string password)
        {
            var login = new { clientId = clientId, password = password };
            var url = new Uri(host, "api/v0/login");
            var webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json; charset=utf-8");
            webClient.Headers.Add("accept", "*/*");
            var s = JsonConvert.SerializeObject(login);
            try
            {
                var token = webClient.UploadString(url, "POST", s);
                _token = JsonConvert.DeserializeObject<Token2>(token);
                return new ApiConnector(host, clientId, _token.access_token);

            }
            catch (Exception ex)
            {
                throw new Exception($"Login failed: {ex.Message}");
            }
        }


    }

}
