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

        public HttpStatusCode StatusCode => throw new System.NotImplementedException();

        public string Get(string road)
        {
            throw new System.NotImplementedException();
        }
    }
}
