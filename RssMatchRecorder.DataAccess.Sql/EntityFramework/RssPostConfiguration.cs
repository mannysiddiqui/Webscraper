using System.Data.Entity.ModelConfiguration;
using RssMatchRecorder.DataAccess.Entities;

namespace RssMatchRecorder.DataAccess.Sql.EntityFramework
{
    public class RssPostConfiguration : EntityTypeConfiguration<RssPost>
    {
        public RssPostConfiguration()
        {
            Property(p => p.FeedId).IsRequired();
            Property(p => p.DateCreated).IsRequired();
        }
    }
}
