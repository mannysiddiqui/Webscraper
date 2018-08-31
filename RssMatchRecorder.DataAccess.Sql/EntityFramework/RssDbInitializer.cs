using System.Data.Entity;
using RssMatchRecorder.DataAccess.Sql.Migrations;

namespace RssMatchRecorder.DataAccess.Sql.EntityFramework
{
    //internal class RssDbInitializer : DropCreateDatabaseAlways<RssContext>
    internal class RssDbInitializer : MigrateDatabaseToLatestVersion<RssContext, Configuration>
    {
/*
        protected override void Seed(RssContext context)
        {
            var feeds = new List<RssFeed>
            {
                new RssFeed()
                {
                    IsRssFeed = true,
                    DateCreated = DateTime.Now,
                    Title = "WAVY, RSS NS Oubound Feed",
                    Url = "https://www.wavy.com/content-syndication-portlet/feedServlet?obfType=RSS_NSFEED&siteId=900050",
                    MatchCriteria = new List<RssFeedMatchCriterion>
                    {
                        new RssFeedMatchCriterion
                        {
                            Description = "Trump",
                            ExactContains = "Trump"
                        }
                    }
                },

                new RssFeed()
                {
                    IsRssFeed = false,
                    DateCreated = DateTime.Now,
                    Title = "Richmond Times-Dispatch",
                    Url = "https://www.richmond.com/news/",
                    MatchCriteria = new List<RssFeedMatchCriterion>
                    {
                        new RssFeedMatchCriterion
                        {
                            Description = "A",
                            ExactContains = "A"
                        }
                    }
                },

                new RssFeed()
                {
                    IsRssFeed = false,
                    DateCreated = DateTime.Now,
                    Title = "WTVR news",
                    Url = "https://wtvr.com/category/news/",
                    MatchCriteria = new List<RssFeedMatchCriterion>
                    {
                        new RssFeedMatchCriterion
                        {
                            Description = "A",
                            ExactContains = "A"
                        }
                    }
                },

                new RssFeed()
                {
                    IsRssFeed = false,
                    DateCreated = DateTime.Now,
                    Title = "WFAE 90.7 Charlotte's NPR News Source",
                    Url = "http://www.wfae.org/news",
                    MatchCriteria = new List<RssFeedMatchCriterion>
                    {
                        new RssFeedMatchCriterion
                        {
                            Description = "A",
                            ExactContains = "A"
                        }
                    }
                },

                new RssFeed()
                {
                    IsRssFeed = true,
                    DateCreated = DateTime.Now,
                    Title = "Richmond2day",
                    Url = "http://richmond2day.com/category/news/feed/",
                    MatchCriteria = new List<RssFeedMatchCriterion>
                    {
                        new RssFeedMatchCriterion
                        {
                            Description = "A",
                            ExactContains = "A"
                        }
                    }
                }
            };

            context.Feeds.AddRange(feeds);

            base.Seed(context);
        }
*/
        
    }
}
