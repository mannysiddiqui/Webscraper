using System;
using System.Collections.Generic;
using RssMatchRecorder.DataAccess.Entities;
using HtmlAgilityPack;

namespace RssMatchRecorder.SiteParser
{
    public abstract class SiteParser
    {
        public List<RssPost> GetPosts(HtmlDocument document)
        {
            var postNodes = GetPostNodes(document);

            var posts = new List<RssPost>();

            foreach (var postNode in postNodes)
            {
                var post = GetPost(postNode);

                posts.Add(post);
            }

            return posts;
        }

        protected abstract IEnumerable<HtmlNode> GetPostNodes(HtmlDocument document);

        protected abstract RssPost GetPost(HtmlNode node);
    }
}
