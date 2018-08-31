using System.ServiceProcess;
using System.Threading;
using log4net.Config;

namespace RssMatchRecorder.Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            ConfigureLogging();

            StartService();
        }

        private static void StartService()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                var service = new RssMatchRecorderService();
                service.Run();

                Thread.Sleep(Timeout.Infinite);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                    new RssMatchRecorderService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

        private static void ConfigureLogging()
        {
            XmlConfigurator.Configure();
        }
    }
}
