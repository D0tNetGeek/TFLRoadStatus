using System.Collections.Specialized;
using System.Configuration;
using TFLRoadStatus.API.Interfaces;

namespace TFLRoadStatus.API
{
    public class Config : IConfig
    {
        public string AppId { get; set; }
        public string AppKey { get; set; }
        public string Url { get; set; }

        public Config()
        {
            var settings = (NameValueCollection)ConfigurationManager.GetSection("tflRoadStatusSettings");

            AppId = settings["app_id"]?.ToString() ?? null;
            AppKey = settings["app_key"]?.ToString() ?? null;
            Url = settings["url"]?.ToString() ?? null;
        }
    }
}
