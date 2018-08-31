using System;
using System.Collections.Generic;
using RssMatchRecorder.DataAccess.Entities;

namespace RssMatchRecorder.DataAccess
{
    public interface IRssRepository
    {
        List<RssFeed> GetFeeds();
        void SaveFeed(RssFeed feed);
        void SavePost(RssPost post);
        void SaveMatchCirterion(RssFeedMatchCriterion criterion);
        void SavePosts(List<RssPost> newPosts);

        List<RssPost> Search(int? feedId, string keyword, DateTime? startDate, DateTime? endDate);
    }
}
