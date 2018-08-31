using System.Data.Entity.ModelConfiguration;
using RssMatchRecorder.DataAccess.Entities;

namespace RssMatchRecorder.DataAccess.Sql.EntityFramework
{
    public class RssFeedConfiguration : EntityTypeConfiguration<RssFeed>
    {
        public RssFeedConfiguration()
        {
            Property(f => f.Title).IsRequired();
            Property(f => f.Url).IsRequired();
            Property(f => f.DateCreated).IsRequired();

            HasMany(f => f.MatchCriteria);
            HasMany(f => f.Posts);
        }
    }
}
