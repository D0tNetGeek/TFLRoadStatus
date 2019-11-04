using Autofac;
using Newtonsoft.Json;
using System.Linq;
using TFLRoadStatus.API.Interfaces;
using TFLRoadStatus.API.Models;
using Xunit;

namespace TFLRoadStatus.Integration.Tests
{
    public class RestClientTest
    {
        private readonly IRestClient _restClient;
        private string _road;

        public RestClientTest()
        {
            _restClient = TFLRoadStatusContainer.Container.Resolve<IRestClient>();
        }

        [Fact]
        public void When_Request_Is_Executed_With_Correct_Road_Then_Returns_Json()
        {
            _road = "A2";
            var expectedRoad = "A2";

            var result = _restClient.Get(_road);

            var road = JsonConvert.DeserializeObject<SeverityStatus[]>(result).First();

            Assert.NotNull(result);
            Assert.Equal(expectedRoad, road.displayName);
        }
    }
}
