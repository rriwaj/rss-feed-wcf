using System;
using System.Collections.Generic;
using RssFeeder.Models;

namespace RssFeeder.Repository
{
    public class ItemFeedRepository
    {
        //Generate random feeds we can replace this with data from database
        public IEnumerable<FeedItem> GetFeedItems(int totalFeeds)
        {
            var feedItems = new List<FeedItem>();
            for (var i = 1; i <= totalFeeds; i++)
            {
                feedItems.Add(new FeedItem
                {
                    Title = "Test Feed " + i,
                    FeedDate = DateTime.Now,
                    Summary = "<b>This is summary of Test Feed " + i + "</b>",
                    FeedUrl = "http://www.google.com",
                    AuthorName = "TestAuthor" + i,
                    AuthorEmail = "testauthor" + i + "@test.com"
                });
            }
            return feedItems;
        }
    }
}