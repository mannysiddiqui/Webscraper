namespace RssMatchRecorder.DataAccess.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201808131030_SetUp_Data_Population : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[RssFeeds] ON 
            ");
            Sql(@"
INSERT  [dbo].[RssFeeds]
        ( [Id] ,
          [IsRssFeed] ,
          [Title] ,
          [Url] ,
          [LastPostUniqueName] ,
          [DateCreated] ,
          [LastPollTime]
        )
VALUES  ( 1 ,
          1 ,
          N'WAVY, RSS NS Oubound Feed' ,
          N'https://www.wavy.com/content-syndication-portlet/feedServlet?obfType=RSS_NSFEED&siteId=900050' ,
          NULL ,
          GETDATE() ,
          NULL
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeeds]
        ( [Id] ,
          [IsRssFeed] ,
          [Title] ,
          [Url] ,
          [LastPostUniqueName] ,
          [DateCreated] ,
          [LastPollTime]
        )
VALUES  ( 2 ,
          0 ,
          N'Richmond Times-Dispatch' ,
          N'https://www.richmond.com/news/' ,
          NULL ,
          GETDATE() ,
          NULL
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeeds]
        ( [Id] ,
          [IsRssFeed] ,
          [Title] ,
          [Url] ,
          [LastPostUniqueName] ,
          [DateCreated] ,
          [LastPollTime]
        )
VALUES  ( 3 ,
          0 ,
          N'WTVR news' ,
          N'https://wtvr.com/category/news/' ,
          NULL ,
          GETDATE() ,
          NULL
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeeds]
        ( [Id] ,
          [IsRssFeed] ,
          [Title] ,
          [Url] ,
          [LastPostUniqueName] ,
          [DateCreated] ,
          [LastPollTime]
        )
VALUES  ( 4 ,
          0 ,
          N'WFAE 90.7 Charlotte''s NPR News Source' ,
          N'http://www.wfae.org/news' ,
          NULL ,
          GETDATE() ,
          NULL
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeeds]
        ( [Id] ,
          [IsRssFeed] ,
          [Title] ,
          [Url] ,
          [LastPostUniqueName] ,
          [DateCreated] ,
          [LastPollTime]
        )
VALUES  ( 5 ,
          1 ,
          N'Richmond2day' ,
          N'http://richmond2day.com/category/news/feed/' ,
          NULL ,
          GETDATE() ,
          NULL
        )
            ");
            Sql(@"
SET IDENTITY_INSERT [dbo].[RssFeeds] OFF
            ");
            Sql(@"
SET IDENTITY_INSERT [dbo].[RssFeedMatchCriterions] ON 

            ");
            Sql(@"
INSERT  [dbo].[RssFeedMatchCriterions]
        ( [Id] ,
          [Description] ,
          [ExactContains] ,
          [RssFeed_Id]
        )
VALUES  ( 1 ,
          N'A' ,
          N'A' ,
          1
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeedMatchCriterions]
        ( [Id] ,
          [Description] ,
          [ExactContains] ,
          [RssFeed_Id]
        )
VALUES  ( 2 ,
          N'A' ,
          N'A' ,
          2
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeedMatchCriterions]
        ( [Id] ,
          [Description] ,
          [ExactContains] ,
          [RssFeed_Id]
        )
VALUES  ( 3 ,
          N'A' ,
          N'A' ,
          3
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeedMatchCriterions]
        ( [Id] ,
          [Description] ,
          [ExactContains] ,
          [RssFeed_Id]
        )
VALUES  ( 4 ,
          N'A' ,
          N'A' ,
          4
        )
            ");
            Sql(@"
INSERT  [dbo].[RssFeedMatchCriterions]
        ( [Id] ,
          [Description] ,
          [ExactContains] ,
          [RssFeed_Id]
        )
VALUES  ( 5 ,
          N'A' ,
          N'A' ,
          5
        )
            ");
            Sql(@"
SET IDENTITY_INSERT [dbo].[RssFeedMatchCriterions] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
