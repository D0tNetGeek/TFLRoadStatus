using Moq;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using TFLRoadStatus.API;
using TFLRoadStatus.API.Interfaces;
using TFLRoadStatus.API.Models;
using TFLRoadStatus.Stubs;
using Xunit;

namespace TFLRoadStatus.Tests
{
    public class HttpClientTest
    {
        private readonly Mock<IConfig> _configMock;
        private readonly HttpClient _httpClient;
        private readonly IRestClient _restClient;
        private string _road;

        public HttpClientTest()
        {
            _configMock = new Mock<IConfig>();
            _httpClient = new HttpClient(new DelegatingHandlerStub());
            _restClient = new RestClient(_configMock.Object, _httpClient);
        }

        [Fact]
        public void When_Execute_Request_With_Correct_Url()
        {
            _road = "A2";
            var expectedRoad = "A2";
            var expectedSeverity = "Good";

            SetupConfigUri("http://localhost/HttpStatus200");

            var roadStatus = GetRoadStatus<SeverityStatus[]>().First();

            Assert.NotNull(roadStatus);

            Assert.Equal(expectedRoad, roadStatus.displayName);
            Assert.Equal(expectedSeverity, roadStatus.statusSeverity);
        }

        [Fact]
        public void When_Execute_Request_With_Wrong_Url()
        {
            _road = "A2";

            SetupConfigUri("http://localhost/HttpStatus400");

            Assert.Throws<HttpRequestException>(() => _restClient.Get(_road));
        }

        [Fact]
        public void When_Execute_Request_With_Invalid_Road_Then_Returns_Json()
        {
            _road = "A223";

            var expectedHttpStatus = "NotFound";
            var expectedHttpStatusCode = "404";

            SetupConfigUri("http://localhost/HttpStatus404");

            var roadStatus = GetRoadStatus<NotFoundStatus>();

            Assert.NotNull(roadStatus);

            Assert.Equal(expectedHttpStatus, roadStatus.httpStatus);
            Assert.Equal(expectedHttpStatusCode, roadStatus.httpStatusCode);
        }

        private T GetRoadStatus<T>()
        {
            var result = _restClient.Get(_road);

            return JsonConvert.DeserializeObject<T>(result);
        }

        private void SetupConfigUri(string uri)
        {
            _configMock.Setup(x => x.Url).Returns(() => uri);
        }
    }
}
