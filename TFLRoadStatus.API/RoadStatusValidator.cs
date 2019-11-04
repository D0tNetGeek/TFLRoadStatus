using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using TFLRoadStatus.API.Interfaces;
using TFLRoadStatus.API.Models;

namespace TFLRoadStatus.API
{
    public class RoadStatusValidator : IRoadStatusValidator
    {
        private IRestClient _restClient;
        private IPrint _print;

        public SeverityStatus _severityStatus { get; set; }
        public NotFoundStatus _notFoundStatus { get; set; }

        public IPrint Print => throw new NotImplementedException();

        public SeverityStatus SeverityStatus { get; set; }
        public NotFoundStatus HttpNotFoundError { get; set; }

        public RoadStatusValidator(IRestClient restClient, IPrint print)
        {
            _restClient = restClient;
            _print = print;
        }

        public int GetCurrentRoadStatus(string road)
        {
            try
            {
                var roadStatus = _restClient.Get(road);

                if (!string.IsNullOrEmpty(roadStatus?.Trim()))
                {
                    if (_restClient.StatusCode == HttpStatusCode.OK)
                    {
                        _severityStatus = JsonConvert.DeserializeObject<SeverityStatus[]>(roadStatus)?.First();

                        PrintStatus();

                        return 0;
                    }
                    else if (_restClient.StatusCode == HttpStatusCode.NotFound)
                    {
                        _notFoundStatus = JsonConvert.DeserializeObject<NotFoundStatus>(roadStatus);

                        PrintError(road);

                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Implement Logging
            }

            return -1;
        }

        private void PrintStatus()
        {
            _print.AddHeader(_severityStatus.displayName);
            _print.AddRoadStatusText("statusSeverity", _severityStatus.statusSeverity);
            _print.AddRoadStatusText("statusSeverityDescription", _severityStatus.statusSeverityDescription);
            _print.PrintStatus();
        }

        private void PrintError(string road)
        {
            _print.AddError(road);
            _print.PrintStatus();
        }
    }
}
