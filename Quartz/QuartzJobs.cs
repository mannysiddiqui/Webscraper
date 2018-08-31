using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using log4net;
using Quartz;
using Quartz.Impl;

namespace RssMatchRecorder.Service.Quartz
{
    public class QuartzJobs
    {
        private const string GroupName = "MatchRecorderJobsGroup";
        private const string DefaultPollingIntervalMinutes = "15";

        public static int PollingIntervalMinutes
            => int.Parse(ConfigurationManager.AppSettings["PollingIntervalMinutes"] ?? DefaultPollingIntervalMinutes);

        private ILog Log { get; } = LogManager.GetLogger(typeof (QuartzJobs));

        private IScheduler Scheduler { get; set; }

        public void Start()
        {
            try
            {
                DoStart().Wait();
                Log.Info("The quartz job has been set up sucessfully.");
            }
            catch (Exception ex)
            {
                Log.Error("Error initializing quartz job.", ex);
                throw;
            }
        }

        public void Stop()
        {
            try
            {
                DoStop().Wait();
                Log.Info("The quartz job has been stopped sucessfully.");
            }
            catch (Exception ex)
            {
                Log.Error("Error shutting down the quartz job.", ex);
                throw;
            }
        }

        private async Task DoStop()
        {
            await Scheduler.Shutdown(false);
        }

        private async Task DoStart()
        {
            var props = new NameValueCollection
            {
                {"quartz.serializer.type", "binary"}
            };
            var factory = new StdSchedulerFactory(props);
            
            Scheduler = await factory.GetScheduler();
            await Scheduler.Start();

            
            var job = JobBuilder.Create<MatchRecorderJob>()
                .WithIdentity("MatchRecorderJob", GroupName)
                .Build();

            
            var trigger = TriggerBuilder.Create()
                .WithIdentity("MatchRecorderJobTrigger", GroupName)
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(PollingIntervalMinutes)
                    .RepeatForever())
                .Build();

            await Scheduler.ScheduleJob(job, trigger);
        }
    }
}