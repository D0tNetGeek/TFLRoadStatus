using Moq;
using System.Net.Http;
using TFLRoadStatus.API;
using TFLRoadStatus.API.Interfaces;
using Xunit;

namespace TFLRoadStatus.Tests
{
    public class RoadStatusValidatorTest
    {
        private string Road;
        private readonly IRestClient _restClient;
        private readonly Mock<IPrint> _printMock;
        private readonly IRoadStatusValidator _roadStatusValidator;
        private readonly Mock<IConfig> _configMock;
        private int _expectedExitCode;

        public RoadStatusValidatorTest()
        {
            _configMock = new Mock<IConfig>();
            _restClient = new RestClient(_configMock.Object, new HttpClient(new DelegatingHandlerStub()));

            _printMock = new Mock<IPrint>();
            _printMock.Object.Message = new System.Text.StringBuilder();
            _roadStatusValidator = new RoadStatusValidator(_restClient, _printMock.Object);
        }

        [Fact]
        public void When_Valid_Request_Is_Executed_Returns_RoadStatus()
        {

        }
    }
}
