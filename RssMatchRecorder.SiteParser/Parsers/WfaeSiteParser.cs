using System;
using System.Collections.Generic;
using RssMatchRecorder.DataAccess.Entities;
using HtmlAgilityPack;

namespace RssMatchRecorder.SiteParser.Parsers
{
    public class WfaeSiteParser : SiteParser
    {
        protected override IEnumerable<HtmlNode> GetPostNodes(HtmlDocument document)
        {
            return document.QuerySelectorAll("div.node-post");
        }

        protected override RssPost GetPost(HtmlNode node)
        {

            var titleLinkElement = node.QuerySelector(".title-info a");
            var title = titleLinkElement?.InnerText;
            var link = $"http://www.wfae.org{titleLinkElement?.Attributes["href"]?.Value}";
            var id = node?.Id;
            var imageLink = node.QuerySelector("figure img")?.Attributes["src"]?.Value;
            var author = node.QuerySelector(".name")?.InnerText;
            var description = node.QuerySelector(".content [property='content:encoded']")?.InnerText;
            var dateText = node.QuerySelector(".submitted [datatype='xsd:dateTime']")?.Attributes?["content"]?.Value;
            var postDate = Convert.ToDateTime(dateText);
            

            return new RssPost()
            {
                PostId = id,
                Link = link,
                Title = title,
                Description = description,
                ImageLink = imageLink,
                PostDate = postDate,
                Author = author,
                DateCreated = DateTime.Now
            };
        }
    }
}
