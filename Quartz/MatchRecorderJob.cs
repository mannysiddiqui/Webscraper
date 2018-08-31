using System.Threading.Tasks;
using RssMatchRecorder.Main;
using Quartz;

namespace RssMatchRecorder.Service.Quartz
{
    public class MatchRecorderJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return new RssMatchRecorderContainer().RecordNewMatchesAsync();
        }
    }
}
