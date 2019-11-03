using System.Net;

namespace TFLRoadStatus.API.Interfaces
{
    public interface IRestClient
    {
        HttpStatusCode StatusCode { get; }
        string Get(string road);
    }
}
