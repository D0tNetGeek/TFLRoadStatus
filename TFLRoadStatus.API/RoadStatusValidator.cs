using TFLRoadStatus.API.Interfaces;

namespace TFLRoadStatus.API
{
    public class RoadStatusValidator : IRoadStatusValidator
    {
        private IRestClient _restClient;
        private IPrint _print;

        public RoadStatusValidator(IRestClient restClient, IPrint print)
        {
            _restClient = restClient;
            _print = print;
        }

        public int GetCurrentRoadStatus(string road)
        {
            throw new System.NotImplementedException();
        }
    }
}
