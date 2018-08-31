using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using RssMatchRecorder.DataAccess.Entities;
using RssMatchRecorder.SiteParser.Parsers;
using HtmlAgilityPack;

namespace RssMatchRecorder.SiteParser
{
    public class SiteParserContainer
    {
        private Dictionary<string, SiteParser> Parsers { get; } = new Dictionary<string, SiteParser>
        {
            {"https://www.richmond.com/news/", new RichmondSiteParser()},
            {"https://wtvr.com/category/news/", new WtvrSiteParser()},
            {"http://www.wfae.org/news", new WfaeSiteParser()}
        };

        public void Test()
        {
            ParseSite(new RssFeed()
            {
                Url = "https://www.richmond.com/news/"
            });
        }

        public List<RssPost> ParseSite(RssFeed site)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var htmlWeb = new HtmlWeb {UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"};
            var document = htmlWeb.Load(site.Url);

            var parser = Parsers[site.Url];

            var posts = parser?.GetPosts(document);
            posts.ForEach(p => p.FeedId = site.Id.Value);

            return posts;
        }
    }
}
