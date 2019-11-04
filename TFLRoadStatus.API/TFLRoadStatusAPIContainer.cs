using Autofac;
using System.Net.Http;
using TFLRoadStatus.API.Interfaces;

namespace TFLRoadStatus.API
{
    public class TFLRoadStatusAPIContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new Config()).As<IConfig>();
            builder.Register(c => new RestClient(c.Resolve<IConfig>(), new HttpClient())).As<IRestClient>();
            builder.Register(c => new Print()).As<IPrint>();
            builder.Register(c => new RoadStatusValidator(c.Resolve<IRestClient>(), c.Resolve<IPrint>())).As<IRoadStatusValidator>();
        }
    }
}
