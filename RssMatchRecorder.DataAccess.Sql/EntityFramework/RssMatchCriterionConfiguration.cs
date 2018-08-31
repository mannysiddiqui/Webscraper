using System.Data.Entity.ModelConfiguration;
using RssMatchRecorder.DataAccess.Entities;

namespace RssMatchRecorder.DataAccess.Sql.EntityFramework
{
    public class RssMatchCriterionConfiguration : EntityTypeConfiguration<RssFeedMatchCriterion>
    {
        public RssMatchCriterionConfiguration()
        {
            Property(c => c.ExactContains).IsRequired();
        }
    }
}
