using System.Threading.Tasks;
using RssMatchRecorder.DataAccess.Sql;
using RssMatchRecorder.SiteParser;

namespace RssMatchRecorder.Main
{
    public class RssMatchRecorderContainer
    {
        public RssMatchRecorderContainer()
        {
            RssMatchRecorder = new Recorder.RssMatchRecorder(new RssSqlRepository(), new SiteParserContainer());
        }

        private Recorder.RssMatchRecorder RssMatchRecorder { get; }

        public void RecordNewMatches()
        {
            RssMatchRecorder.RecordNewMatches().Wait();
        }

        public async Task RecordNewMatchesAsync()
        {
            await RssMatchRecorder.RecordNewMatches();
        }
    }
}