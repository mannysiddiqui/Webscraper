using System;
using System.Collections.Generic;
using RssMatchRecorder.DataAccess.Entities;
using HtmlAgilityPack;

namespace RssMatchRecorder.SiteParser.Parsers
{
    public class RichmondSiteParser : SiteParser
    {
        protected override IEnumerable<HtmlNode> GetPostNodes(HtmlDocument document)
        {
            return document.QuerySelectorAll("article.card.summary.image-left");
        }

        protected override RssPost GetPost(HtmlNode node)
        {
            var linkElement = node.QuerySelector(".tnt-headline a");
            var text = linkElement.InnerText?.Trim();
            var link = $"https://www.richmond.com{linkElement.Attributes["href"]?.Value}";
            var imageElement = node.QuerySelector("figure img.img-responsive");
            var imageLink =
                imageElement?.Attributes["data-srcset"]?.Value?.Split(new[] { ',' },
                    StringSplitOptions.RemoveEmptyEntries)[0]?.Trim();


            var postDate = GetRichmondComPostDate(node);

            return new RssPost()
            {
                PostId = node.Id,
                Link = link,
                Title = text,
                ImageLink = imageLink,
                PostDate = postDate,
                DateCreated = DateTime.Now
            };
        }

        private static DateTime? GetRichmondComPostDate(HtmlNode node)
        {
            string dateText = null;
            var dateNode = node.PreviousSibling;
            dateText = dateNode?.QuerySelector(".date-partition .date")?.InnerText;

            DateTime? postDate = null;

            while (dateText == null && dateNode != null)
            {
                dateNode = dateNode.PreviousSibling;
                dateText = dateNode?.QuerySelector(".date-partition .date")?.InnerText;
                postDate = !string.IsNullOrWhiteSpace(dateText) ? Convert.ToDateTime(dateText) : (DateTime?)null;
            }
            return postDate;
        }

    }
}
