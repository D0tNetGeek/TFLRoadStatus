namespace TFLRoadStatus.API.Interfaces
{
    public interface IConfig
    {
        string AppId { get; set; }
        string AppKey { get; set; }
        string Url { get; set; }
    }
}
