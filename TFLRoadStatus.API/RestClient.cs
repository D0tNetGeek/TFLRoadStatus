using System.Net;
using System.Net.Http;
using TFLRoadStatus.API.Interfaces;

namespace TFLRoadStatus.API
{
    public class RestClient : IRestClient
    {
        private IConfig _config;
        private readonly HttpClient _httpClient;

        public RestClient(IConfig config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }

        public HttpStatusCode StatusCode { get; private set; }

        public string Get(string road)
        {
            string content = string.Empty;

            using (_httpClient)
            {
                var requestUrl = CreateUrl(road);

                var httpContent = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpResponseMessage response = _httpClient.SendAsync(httpContent).Result;

                StatusCode = response.StatusCode;

                if(response.StatusCode !=HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotFound)
                {
                    throw new HttpRequestException($"Error request http status code {response.StatusCode}");
                }

                content = response.Content.ReadAsStringAsync().Result;
            }

            return content;
        }

        private string CreateUrl(string road)
        {
            return string.Format(_config.Url + "{0}?app_id{1}&app_key={2}", road, _config.AppId, _config.AppKey);
        }
    }
}
