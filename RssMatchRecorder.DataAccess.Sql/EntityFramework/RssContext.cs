using System.Data.Entity;
using RssMatchRecorder.DataAccess.Entities;

namespace RssMatchRecorder.DataAccess.Sql.EntityFramework
{
    public class RssContext : DbContext
    {
        public RssContext() : base("RSSMatchesDatabase")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<RssContext>());
            Database.SetInitializer(new RssDbInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new RssFeedConfiguration());
            modelBuilder.Configurations.Add(new RssPostConfiguration());
            modelBuilder.Configurations.Add(new RssMatchCriterionConfiguration());
        }

        public DbSet<RssFeed> Feeds { get; set; }

        public DbSet<RssPost> Posts { get; set; }

        public DbSet<RssFeedMatchCriterion> MatchCriteria { get; set; }
    }
}
