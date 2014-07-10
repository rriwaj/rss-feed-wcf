using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using RssFeeder.Repository;

namespace RssFeeder.Service
{
    public class FeedService : IFeedService
    {
        private readonly ItemFeedRepository _feedRepository = new ItemFeedRepository();
        public SyndicationFeed GenerateFeeds(int noOfFeeds)
        {
            var feed = new SyndicationFeed
            {
                Title = new TextSyndicationContent("A simple rss feeder."),
                Language = "en-us",
                LastUpdatedTime = DateTime.Now,
                Copyright = new TextSyndicationContent("RRiwaj"),
                Description = new TextSyndicationContent("This is a simple rss feeder created using WCF Syndication class."),
                ImageUrl = new Uri("/Contents/Images/rss.png", UriKind.Relative)
            };
            var itemsRepo = _feedRepository.GetFeedItems(noOfFeeds); // Get Item Feeds from feed repository.
            var feedItems = new List<SyndicationItem>(); // Create new Syndication Item List which will be added to Syndication Feed
            foreach (var proxyItem in itemsRepo)
            {
                var item = new SyndicationItem
                {
                    Title = SyndicationContent.CreatePlaintextContent(proxyItem.Title),
                    PublishDate = proxyItem.FeedDate,
                    Summary = SyndicationContent.CreateHtmlContent(proxyItem.Summary)
                };
                item.Links.Add(SyndicationLink.CreateAlternateLink(new Uri(proxyItem.FeedUrl)));
                var authInfo = new SyndicationPerson
                {
                    Name = proxyItem.AuthorName,
                    Email = proxyItem.AuthorEmail
                };
                item.Authors.Add(authInfo);
                feedItems.Add(item);
            }
            feed.Items = feedItems;
            return feed;
        }
    }
}