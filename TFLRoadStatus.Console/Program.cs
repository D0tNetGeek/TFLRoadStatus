using Autofac;
using System.Linq;
using TFLRoadStatus.API.Interfaces;

namespace TFLRoadStatus.Console
{
    class Program
    {
        static int Main(string[] args)
        {
            var roadStatusApp = RoadStatusContainer.Container.Resolve<IRoadStatusValidator>();

            string parameter;

            if ((parameter = ParseArgs(args)) != null)
                return roadStatusApp.GetCurrentRoadStatus(parameter);

            return -1;
        }

        private static string ParseArgs(string[] args)
        {
            if (args != null && args.Length == 1)
                return args.First();

            PrintHelp();

            return null;
        }

        private static void PrintHelp()
        {
            var print = RoadStatusContainer.Container.Resolve<IPrint>();

            print.AddHelp().PrintStatus();
        }
    }
}
