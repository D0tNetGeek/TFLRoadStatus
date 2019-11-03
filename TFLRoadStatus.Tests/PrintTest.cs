using TFLRoadStatus.API;
using TFLRoadStatus.API.Interfaces;
using Xunit;

namespace TFLRoadStatus.Tests
{
    public class PrintTest
    {
        private readonly IPrint _print;

        public PrintTest()
        {
            _print = new Print();
        }

        [Fact]
        public void When_AddHeader_Is_Executed_Returns_AddedText()
        {
            string text = "A2";
            string expectedText = "The status of the A2 is as follows\r\n";

            _print.AddHeader(text);

            var content = _print.Message.ToString();

            Assert.Equal(expectedText, content);
        }

        [Fact]
        public void When_ReportConstant_StatusSeverity_Is_Executed_Return_AddedText()
        {
            string expectedText = "Road Status\r\n";

            string statusSeverity = _print.ReportConstants["statusSeverity"];

            Assert.Equal(expectedText, expectedText);
        }

        [Fact]
        public void When_ReportConstant_StatusSeverityDescription_Is_Executed_Returns_AddedText()
        {
            string expectedText = "Road Status Description\r\n";

            string statusSeverityDescription = _print.ReportConstants["statusSeverityDescription"];

            Assert.Equal(expectedText, expectedText);
        }

        [Fact]
        public void When_AddHeaderText_StatusSeverity_Is_Executed_Returns_AddedText()
        {
            string key = "statusSeverity";
            string text = "Good";
            string expectedText = "\tRoad Status is Good\r\n";

            _print.AddRoadStatusText(key, text);

            var content = _print.Message.ToString();

            Assert.Equal(expectedText, content);
        }

        public void When_AddedHeaderText_StatusSeverityDescription_Is_Executed_Returns_AddedText()
        {
            string key = "statusSeverityDescription";
            string text = "No ExceptionDelays";
            string expectedText = "\tRoad Status Description is No Exceptional Delays\r\n";

            _print.AddRoadStatusText(key, text);

            var content = _print.Message.ToString();

            Assert.Equal(expectedText, content);
        }
    }
}
