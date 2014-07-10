using System.Web.Mvc;
using RssFeeder.Helpers;
using RssFeeder.Service;

namespace RssFeeder.Controllers
{
    public class FeedController : Controller
    {
        private readonly FeedService _feedService = new FeedService();

        //
        // GET: /RssFeeder/XmlFileFeed
        [HttpGet]
        public ActionResult XmlFileFeed(FeedType feedType, int noOfFeeds)
        {
            return new RssResult(_feedService.GenerateFeeds(noOfFeeds), feedType);
        }
        //
        // GET: /RssFeeder/XmlStreamFeed
        [HttpGet]
        public ActionResult XmlStreamFeed(FeedType feedType, int noOfFeeds)
        {
            return new RssActionResult(_feedService.GenerateFeeds(noOfFeeds), feedType);
        }
    }
}
public enum FeedType
{
    Atom = 1,
    Rss = 2
}