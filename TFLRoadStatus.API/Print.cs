using System.Collections.Generic;
using System.Text;
using TFLRoadStatus.API.Interfaces;

namespace TFLRoadStatus.API
{
    public class Print : IPrint
    {
        public Dictionary<string, string> ReportConstants => throw new System.NotImplementedException();

        public StringBuilder Message { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IPrint AddError(string text)
        {
            throw new System.NotImplementedException();
        }

        public IPrint AddHeader(string text)
        {
            throw new System.NotImplementedException();
        }

        public IPrint AddHelp()
        {
            throw new System.NotImplementedException();
        }

        public IPrint AddRoadStatusText(string key, string text)
        {
            throw new System.NotImplementedException();
        }

        public void PrintStatus()
        {
            throw new System.NotImplementedException();
        }
    }
}
