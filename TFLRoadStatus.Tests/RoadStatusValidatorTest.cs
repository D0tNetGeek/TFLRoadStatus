using Moq;
using System.Net.Http;
using TFLRoadStatus.API;
using TFLRoadStatus.API.Interfaces;
using TFLRoadStatus.Stubs;
using Xunit;

namespace TFLRoadStatus.Tests
{
    public class RoadStatusValidatorTest
    {
        private string _road;
        private readonly IRestClient _restClient;
        private readonly Mock<IPrint> _printMock;
        private readonly IRoadStatusValidator _roadStatusValidator;
        private readonly Mock<IConfig> _configMock;
        private int expectedExitCode;

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
            _road = "A2";
            expectedExitCode = 0;
            _configMock.Setup(x => x.Url).Returns(() => "http://localhost/HttpStatus200");

            var actualExitCode = _roadStatusValidator.GetCurrentRoadStatus(_road);

            Assert.Equal(expectedExitCode, actualExitCode);
            _printMock.Verify(x=>x.AddError(_road), Times.Once);
            _printMock.Verify(x => x.PrintStatus(), Times.Once);
        }

        [Fact]
        public void When_Invalid_Request_Is_Executed_Returns_NotFound_Error()
        {
            _road = "A223";
            expectedExitCode = 1;
            _configMock.Setup(x => x.Url).Returns(() => "http://localhost/HttpStatus404");

            var actualExitCode = _roadStatusValidator.GetCurrentRoadStatus(_road);

            Assert.Equal(expectedExitCode, actualExitCode);
            _printMock.Verify(x => x.AddError(_road), Times.Once);
            _printMock.Verify(x => x.PrintStatus(), Times.Once);
        }
    }
}
