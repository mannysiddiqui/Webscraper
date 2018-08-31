using System;

namespace RssMatchRecorder.DataAccess.Entities
{
  public class RssPost : IEntity
    {
        public int? Id { get; set; }
        public string PostId { get; set; }
        public int FeedId { get; set; }
        public string Title { get; set; }
        public DateTime? PostDate { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string ImageLink { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
