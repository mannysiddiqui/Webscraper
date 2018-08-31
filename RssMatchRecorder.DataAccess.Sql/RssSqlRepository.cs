using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RssMatchRecorder.DataAccess.Entities;
using RssMatchRecorder.DataAccess.Sql.EntityFramework;

namespace RssMatchRecorder.DataAccess.Sql
{
    public class RssSqlRepository : IRssRepository
    {
        public List<RssFeed> GetFeeds()
        {
            using (var ctx = new RssContext())
            {
                return ctx.Feeds.Include(f => f.Posts).Include(f => f.MatchCriteria).ToList();
            }
        }

        public void SaveFeed(RssFeed feed)
        {
            using (var ctx = new RssContext())
            {
                AddOrUpdate(feed, ctx);

                ctx.SaveChanges();
            }
        }

        public void SavePost(RssPost post)
        {
            using (var ctx = new RssContext())
            {
                AddOrUpdate(post, ctx);

                ctx.SaveChanges();
            }
        }

        public void SavePosts(List<RssPost> newPosts)
        {
            using (var ctx = new RssContext())
            {
                foreach (var newPost in newPosts)
                {
                    AddOrUpdate(newPost, ctx);
                }

                ctx.SaveChanges();
            }
        }

        public void SaveMatchCirterion(RssFeedMatchCriterion criterion)
        {
            using (var ctx = new RssContext())
            {
                AddOrUpdate(criterion, ctx);

                ctx.SaveChanges();
            }
        }

        public List<RssPost> Search(int? feedId, string keyword, DateTime? startDate, DateTime? endDate)
        {
            using (var ctx = new RssContext())
            {
                var query = (IQueryable<RssPost>) ctx.Posts;

                if (feedId != null)
                {
                    query = query.Where(p => p.FeedId == feedId);
                }

                if (keyword != null)
                {
                    query =
                        query.Where(
                            p =>
                                p.Title.Contains(keyword) || p.Description.Contains(keyword) ||
                                p.Content.Contains(keyword));
                }


                if (startDate != null)
                {
                    query = query.Where(p => p.PostDate >= startDate);
                }

                if (endDate != null)
                {
                    query = query.Where(p => p.PostDate <= endDate);
                }

                return query.ToList();
            }
        }

        private static void AddOrUpdate(IEntity entity, RssContext ctx)
        {
            ctx.Entry(entity).State = entity.Id != null ? EntityState.Modified : EntityState.Added;
        }
    }
}
