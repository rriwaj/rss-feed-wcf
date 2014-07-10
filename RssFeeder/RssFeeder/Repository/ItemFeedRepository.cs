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
                    Title = "This is feed no " + i,
                    FeedDate = DateTime.Now,
                    Summary = "A simple rss feed which is randomly generated all of these values are hardcoded for test purpose. We can replace this static value by retrieving data from database. ",
                    FeedUrl = "http://www.google.com",
                    AuthorName = "Rriwaj" + i,
                    AuthorEmail = "riwajrimal@gmail.com"
                });
            }
            return feedItems;
        }
    }
}