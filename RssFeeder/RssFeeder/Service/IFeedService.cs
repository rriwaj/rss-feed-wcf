using System.ServiceModel.Syndication;

namespace RssFeeder.Service
{
    public interface IFeedService
    {
        SyndicationFeed GenerateFeeds(int noOfFeeds);
    }
}
