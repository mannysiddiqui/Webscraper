using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RssMatchRecorder.DataAccess.Entities;
using HtmlAgilityPack;

namespace RssMatchRecorder.SiteParser.Parsers
{
    public class WtvrSiteParser : SiteParser
    {
        private Regex PostDateRegex { get; } = new Regex(@".+wtvr\.com/(\d{4})/(\d{1,2})/(\d{1,2})", RegexOptions.Compiled);

        protected override IEnumerable<HtmlNode> GetPostNodes(HtmlDocument document)
        {
            return document.QuerySelectorAll("div.story,li.story");
        }

        protected override RssPost GetPost(HtmlNode node)
        {
            var linkElement = node.QuerySelector(".entry-title a");
            
            var title = linkElement?.InnerText;
            var link = linkElement?.Attributes["href"]?.Value;
            
            var imageElement = node.QuerySelector("a.story-image img");
            var imageLink = imageElement?.Attributes["src"]?.Value;

            DateTime? postDate = GetPostDateFromLink(link);

            return new RssPost()
            {
                PostDate = postDate,
                DateCreated = DateTime.Now,
                PostId = link,
                Title = title,
                ImageLink = imageLink,
                Link = link
            };
        }

        private DateTime? GetPostDateFromLink(string postLink)
        {
            if (postLink != null)
            {
                var match = PostDateRegex.Match(postLink);
                if (match.Success)
                {
                    var year = int.Parse(match.Groups[1].Value);
                    var month = int.Parse(match.Groups[2].Value);
                    var day = int.Parse(match.Groups[3].Value);

                    return new DateTime(year, month, day);
                }
            }
            
            return null;
        }
    }
}
