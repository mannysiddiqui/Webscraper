using System;
using System.Collections.Generic;
using RssMatchRecorder.DataAccess.Entities;

namespace RssMatchRecorder.DataAccess.Entities
{
    public class RssFeed : IEntity
    {
        public int? Id { get; set; }
        public bool IsRssFeed { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string LastPostUniqueName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastPollTime { get; set; }

        public virtual List<RssFeedMatchCriterion> MatchCriteria { get; set; }
        public virtual List<RssPost> Posts { get; set; }
    }
}
