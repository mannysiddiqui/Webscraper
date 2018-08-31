namespace RssMatchRecorder.DataAccess.Entities
{
    public class RssFeedMatchCriterion : IEntity
    {
        public int? Id { get; set; }
        public string Description { get; set;}
        public string ExactContains { get; set; }
    }
}
