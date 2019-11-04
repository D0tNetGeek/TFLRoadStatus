using Autofac;
using TFLRoadStatus.API;

namespace TFLRoadStatus.Console
{
    public static class RoadStatusContainer
    {
        public static IContainer Container { get; set; }

        static RoadStatusContainer()
        {
            Container = Build();
        }

        private static IContainer Build()
        {
            var container = new ContainerBuilder();

            container.RegisterModule(new TFLRoadStatusAPIContainer());

            return container.Build();
        }
    }
}
