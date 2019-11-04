using Autofac;
using TFLRoadStatus.API;

namespace TFLRoadStatus.Integration.Tests
{
    public static class TFLRoadStatusContainer
    {
        public static IContainer Container { get; set; }

        static TFLRoadStatusContainer()
        {
            Container = Build();
        }

        private static Autofac.IContainer Build()
        {
            var container = new ContainerBuilder();

            container.RegisterModule(new TFLRoadStatusAPIContainer());

            return container.Build();
        }
    }
}
