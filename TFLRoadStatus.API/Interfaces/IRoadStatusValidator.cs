using TFLRoadStatus.API.Models;

namespace TFLRoadStatus.API.Interfaces
{
    public interface IRoadStatusValidator
    {
        int GetCurrentRoadStatus(string road);
        IPrint Print { get; }
        SeverityStatus SeverityStatus { get; set; }
        NotFoundStatus HttpNotFoundError { get; set; }
    }
}
