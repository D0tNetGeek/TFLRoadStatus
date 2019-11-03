using Moq;
using System.Net.Http;
using TFLRoadStatus.API;
using TFLRoadStatus.API.Interfaces;
using TFLRoadStatus.Stubs;

namespace TFLRoadStatus.Tests
{
    public class HttpClientTest
    {
        private readonly Mock<IConfig> _configMock;
        private readonly HttpClient _httpClient;
        private readonly IRestClient _restClient;
        private string road;

        public HttpClientTest()
        {
            _configMock = new Mock<IConfig>();
            _httpClient = new HttpClient(new DelegatingHandlerStub());
            _restClient = new RestClient(_configMock.Object, _httpClient);
        }
    }
}
