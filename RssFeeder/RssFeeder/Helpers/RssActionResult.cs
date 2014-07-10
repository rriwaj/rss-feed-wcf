using System.ServiceModel.Syndication;
using System.Web.Mvc;
using System.Xml;

namespace RssFeeder.Helpers
{
    public class RssActionResult : ActionResult
    {
        private readonly SyndicationFeed _feed;
        private readonly FeedType _feedType;
        private bool _isRssFeed;
        public RssActionResult(SyndicationFeed feed, FeedType feedType)
        {
            _feed = feed;
            _feedType = feedType;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            _isRssFeed = _feedType == FeedType.Rss;
            context.HttpContext.Response.ContentType = _isRssFeed
                        ? "application/rss+xml"
                        : "application/atom+xml";
            var writerSettings = new XmlWriterSettings { Indent = true };
            using (var feedWriter = XmlWriter.Create(context.HttpContext.Response.OutputStream, writerSettings))
            {
                if (_isRssFeed)
                {
                    // RSS 2.0
                    var rssFormatter = new Rss20FeedFormatter(_feed);
                    rssFormatter.WriteTo(feedWriter);
                }
                else
                {
                    var atomFormatter = new Atom10FeedFormatter(_feed);
                    atomFormatter.WriteTo(feedWriter);
                }
            }
        }
    }

}