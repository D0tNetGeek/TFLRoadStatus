using Autofac;
using TFLRoadStatus.API;

namespace TFLRoadStatus.Tests
{
    public class TFLRoadStatusContainer
    {
        public static Autofac.IContainer Container { get; set; }

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
