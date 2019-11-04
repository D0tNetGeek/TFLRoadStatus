using Moq;
using System.Net.Http;
using TechTalk.SpecFlow;
using TFLRoadStatus.API;
using TFLRoadStatus.API.Interfaces;
using TFLRoadStatus.Stubs;
using Xunit;

namespace TFLRoadStatus.Specs.Steps
{
    [Binding, Scope(Feature = "SeverityStatus")]
    public sealed class SeverityStatusSteps
    {
        private const string Severity = "Good";
        private const string SeverityDescription = "No Exceptional Delays";
        private const string Road = "A2";

        private const int ExpectedExitCode = 0;
        private string _requestRoad;
        private int ExitCode;

        private readonly IRestClient _restClient;
        private readonly IPrint _print;
        private readonly IRoadStatusValidator _roadStatusValidator;

        private readonly Mock<IConfig> _configMock;

        public SeverityStatusSteps()
        {
            _configMock = new Mock<IConfig>();
            _configMock.Setup(x => x.Url).Returns(() => "http://localhost/HttpStatus200");

            _restClient = new RestClient(_configMock.Object, new HttpClient(new DelegatingHandlerStub()));

            _print = new Print();

            _roadStatusValidator = new RoadStatusValidator(_restClient, _print);
        }

        [Given(@"a valid road ID A(.*) is specified")]
        public void GivenAValidRoadIDAIsSpecified(string road)
        {
            _requestRoad = road;
        }


        [When(@"the client is run")]
        public void WhenTheClientIsRun()
        {
            ExitCode = _roadStatusValidator.GetCurrentRoadStatus(_requestRoad);
        }

        [Then(@"the road '(.*)' should be displayed")]
        public void ThenTheRoadShouldBeDisplayed(string displayName)
        {
            Assert.Equal(ExpectedExitCode, ExitCode);
            Assert.NotNull(_roadStatusValidator.SeverityStatus.displayName);
            Assert.NotEmpty(_roadStatusValidator.SeverityStatus.displayName);

            Assert.Equal(_requestRoad, _roadStatusValidator.SeverityStatus.displayName);
        }

        [Then(@"the road '(.*)' should be diplayed as '(.*)'")]
        public void ThenTheRoadShouldBeDiplayedAs(string key, string text)
        {
            Assert.Equal(_roadStatusValidator.Print.ReportConstants[key], text);
            Assert.Equal(ExpectedExitCode, ExitCode);
            Assert.NotNull(_roadStatusValidator.SeverityStatus.statusSeverity);
            Assert.NotEmpty(_roadStatusValidator.SeverityStatus.statusSeverity);
        }

        [Then(@"the road '(.*)' should b displayed as '(.*)'")]
        public void ThenTheRoadShouldBDisplayedAs(string key, string text)
        {
            Assert.Equal(_roadStatusValidator.Print.ReportConstants[key], text);
            Assert.Equal(ExpectedExitCode, ExitCode);
            Assert.NotNull(_roadStatusValidator.SeverityStatus.statusSeverity);
            Assert.NotEmpty(_roadStatusValidator.SeverityStatus.statusSeverity);
        }
    }
}