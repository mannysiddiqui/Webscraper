using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using RssMatchRecorder.DataAccess;
using RssMatchRecorder.DataAccess.Entities;
using RssMatchRecorder.SiteParser;
using CodeHollow.FeedReader;

namespace RssMatchRecorder.Recorder
{
    public class RssMatchRecorder
    {
        private IRssRepository RssRepository { get;  }
        private SiteParserContainer SiteParser { get; }

        public RssMatchRecorder(IRssRepository rssRepository, SiteParserContainer siteParser)
        {
            RssRepository = rssRepository;
            SiteParser = siteParser;
        }

        public async Task RecordNewMatches()
        {
            foreach (RssFeed feed in RssRepository.GetFeeds())
            {
                var newPosts = await GetNewPosts(feed);

                if (newPosts.Any())
                {
                    feed.LastPollTime = DateTime.Now;
                    feed.LastPostUniqueName = newPosts.FirstOrDefault()?.PostId ?? feed.LastPostUniqueName;

                    var matchingPosts = newPosts.Where(post => PostMatches(post, feed.MatchCriteria));

                    feed.Posts.AddRange(matchingPosts);

                    RssRepository.SavePosts(matchingPosts.ToList());
                    
                    RssRepository.SaveFeed(feed);
                }
            }
        }

        private bool PostMatches(RssPost post, RssFeedMatchCriterion matchCriterion)
        {
            return FieldMatches(post.Content, matchCriterion) || FieldMatches(post.Title, matchCriterion) ||
                   FieldMatches(post.Description, matchCriterion);
        }

        private bool FieldMatches(string fieldValue, RssFeedMatchCriterion matchCriterion)
        {
            return fieldValue?.IndexOf(matchCriterion.ExactContains, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }

        private bool PostMatches(RssPost post, List<RssFeedMatchCriterion> matchCriteria)
        {
            return matchCriteria.Any(c => PostMatches(post, c));
        }

        private async Task<List<RssPost>> GetNewPosts(RssFeed feedEntity)
        {
            if (feedEntity.IsRssFeed)
            {
                return await GetNewRssPosts(feedEntity);
            }
            else
            {
                return GetNewSitePosts(feedEntity);
            }
        }

        private List<RssPost> GetNewSitePosts(RssFeed feedEntity)
        {
            var allPosts = SiteParser.ParseSite(feedEntity);

            return allPosts.TakeWhile(p => p.PostId != feedEntity.LastPostUniqueName).ToList();
        }

        private static async Task<List<RssPost>> GetNewRssPosts(RssFeed feedEntity)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var feed = await FeedReader.ReadAsync(feedEntity.Url);

            var posts = new List<RssPost>();

            foreach (var feedItem in feed.Items)
            {
                //assuming newest posts come first
                if (feedItem.Id == feedEntity.LastPostUniqueName)
                {
                    break;
                }

                posts.Add(new RssPost()
                {
                    FeedId = feedEntity.Id.Value,
                    Author = feedItem.Author,
                    Title = feedItem.Title,
                    Content = feedItem.Content,
                    Description = feedItem.Description,
                    PostDate = feedItem.PublishingDate,
                    DateCreated = DateTime.Now,
                    Link = feedItem.Link,
                    PostId = feedItem.Id
                });
            }

            return posts;
        }
    }
}
