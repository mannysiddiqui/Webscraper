namespace RssMatchRecorder.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RssMatchRecorder.DataAccess.Sql.EntityFramework.RssContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RssMatchRecorder.DataAccess.Sql.EntityFramework.RssContext";
        }

        protected override void Seed(RssMatchRecorder.DataAccess.Sql.EntityFramework.RssContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
