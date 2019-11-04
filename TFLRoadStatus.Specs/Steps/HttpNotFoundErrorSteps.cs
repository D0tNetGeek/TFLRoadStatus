using Moq;
using System.Net.Http;
using TechTalk.SpecFlow;
using TFLRoadStatus.API;
using TFLRoadStatus.API.Interfaces;
using TFLRoadStatus.Stubs;
using Xunit;

namespace TFLRoadStatus.Specs.Steps
{
    [Scope(Feature = "HttpNotFoundError")]
    [Binding]
    public class HttpNotFoundErrorSteps
    {
        private int ExitCode;

        private readonly IRestClient _restClient;
        private readonly IPrint _print;
        private readonly IRoadStatusValidator _roadStatusValidator;

        private readonly Mock<IConfig> _configMock;

        public HttpNotFoundErrorSteps()
        {
            _configMock = new Mock<IConfig>();
            _configMock.Setup(x => x.Url).Returns(() => "http://localhost/HttpStatus404");

            _restClient = new RestClient(_configMock.Object, new HttpClient(new DelegatingHandlerStub()));

            _print = new Print();

            _roadStatusValidator = new RoadStatusValidator(_restClient, _print);
        }

        [Given(@"an invalid road ID A(.*) is specified")]
        public void GivenAnInvalidRoadIDAIsSpecified(string road)
        {
            ExitCode = _roadStatusValidator.GetCurrentRoadStatus(road);
        }

        [Then(@"the application should return an infomative error")]
        public void ThenTheApplicationShouldReturnAnInfomativeError()
        {
            var expectedHttpStatusCode = "404";
            var expectedHttpStatus = "NotFound";

            Assert.Equal(expectedHttpStatusCode, _roadStatusValidator.HttpNotFoundError.httpStatusCode);
            Assert.Equal(expectedHttpStatus, _roadStatusValidator.HttpNotFoundError.httpStatus);
        }

        [Then(@"the application should exit with a non-zero System Error code")]
        public void ThenTheApplicationShouldExitWithANon_ZeroSystemErrorCode()
        {
            var expectedExitCode = 1;

            Assert.Equal(expectedExitCode, ExitCode);
        }
    }
}
