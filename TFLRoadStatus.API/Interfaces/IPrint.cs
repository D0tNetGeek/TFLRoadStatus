using System.Collections.Generic;
using System.Text;

namespace TFLRoadStatus.API.Interfaces
{
    public interface IPrint
    {
        Dictionary<string, string> ReportConstants { get; }
        StringBuilder Message { get; set; }
        IPrint AddHeader(string text);
        IPrint AddRoadStatusText(string key, string text);
        IPrint AddError(string text);
        IPrint AddHelp();
        void PrintStatus();
    }
}
