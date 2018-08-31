using System.ServiceProcess;
using RssMatchRecorder.Service.Quartz;

namespace RssMatchRecorder.Service
{
    public partial class RssMatchRecorderService : ServiceBase
    {
        private QuartzJobs QuartzJobs { get; set; }

        public RssMatchRecorderService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Run();
        }

        public void Run()
        {
            QuartzJobs = new QuartzJobs();
            QuartzJobs.Start();
        }

        protected override void OnStop()
        {
            QuartzJobs.Stop();
        }
    }
}
