namespace RssMatchRecorder.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201808131009_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RssFeeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsRssFeed = c.Boolean(nullable: false),
                        Title = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        LastPostUniqueName = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        LastPollTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RssFeedMatchCriterions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ExactContains = c.String(nullable: false),
                        RssFeed_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RssFeeds", t => t.RssFeed_Id)
                .Index(t => t.RssFeed_Id);
            
            CreateTable(
                "dbo.RssPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.String(),
                        FeedId = c.Int(nullable: false),
                        Title = c.String(),
                        PostDate = c.DateTime(),
                        Author = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        Link = c.String(),
                        ImageLink = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        RssFeed_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RssFeeds", t => t.RssFeed_Id)
                .Index(t => t.RssFeed_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RssPosts", "RssFeed_Id", "dbo.RssFeeds");
            DropForeignKey("dbo.RssFeedMatchCriterions", "RssFeed_Id", "dbo.RssFeeds");
            DropIndex("dbo.RssPosts", new[] { "RssFeed_Id" });
            DropIndex("dbo.RssFeedMatchCriterions", new[] { "RssFeed_Id" });
            DropTable("dbo.RssPosts");
            DropTable("dbo.RssFeedMatchCriterions");
            DropTable("dbo.RssFeeds");
        }
    }
}
