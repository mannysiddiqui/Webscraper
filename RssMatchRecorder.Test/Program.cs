using RssMatchRecorder.Main;
using RssMatchRecorder.SiteParser;

namespace RssMatchRecorder.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            new RssMatchRecorderContainer().RecordNewMatches();
            //new SiteParserContainer().Test();
        }
    }
}
