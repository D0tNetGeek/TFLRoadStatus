using System;
using System.Collections.Generic;
using System.Text;
using TFLRoadStatus.API.Interfaces;

namespace TFLRoadStatus.API
{
    public class Print : IPrint
    {
        public Dictionary<string, string> ReportConstants { get; } = new Dictionary<string, string>()
        {
            { "statusSeverity", "Road Status" },
            { "statusSeverityDescription", "Road Status Description" }
        };

        public StringBuilder Message { get; set; } = new StringBuilder();

        public IPrint AddError(string text)
        {
            Message.AppendLine($"{text} is not a valid road");

            return this;
        }

        public IPrint AddHeader(string text)
        {
            Message.AppendLine($"The status of the {text} is as follows");

            return this;
        }

        public IPrint AddHelp()
        {
            Message.Clear();

            Message.AppendLine($"Please enter:");
            Message.AppendLine($"\tTFLRoadStatus.Console <RoadName>");

            return this;
        }

        public IPrint AddRoadStatusText(string key, string text)
        {
            Message.AppendLine($"\t{ReportConstants[key]} is {text}");

            return this;
        }

        public void PrintStatus()
        {
            Console.WriteLine(Message.ToString());
        }
    }
}
