using System;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace RssFeeder.Helpers
{
    public class RssResult : FileResult
    {
        private readonly SyndicationFeed _feed;
        private readonly FeedType _feedType;
        private bool _isRssFeed;
        public RssResult(SyndicationFeed feed, FeedType feedType)
            : base("application/rss+xml")
        {
            _feed = feed;
            _feedType = feedType;
        }
        protected override void WriteFile(HttpResponseBase response)
        {
            _isRssFeed = _feedType == FeedType.Rss;

            // Creates Xml file.
            string xmlFile = HttpContext.Current.Server.MapPath("~/feed.xml");
            using (var fileStream = new FileStream(xmlFile, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    var xs = new XmlWriterSettings { Indent = true };
                    using (var xmlWriter = XmlWriter.Create(streamWriter, xs))
                    {
                        xmlWriter.WriteStartDocument();
                        if (_isRssFeed)
                        {
                            // RSS 2.0
                            var rssFormatter = new Rss20FeedFormatter(_feed);
                            rssFormatter.WriteTo(xmlWriter);
                        }
                        else
                        {
                            // Atom 1.0
                            var atomFormatter = new Atom10FeedFormatter(_feed);
                            atomFormatter.WriteTo(xmlWriter);
                        }
                    }
                }
            }
            //Display Xml file in browser.
            response.Clear();
            response.Buffer = true;
            response.Charset = "";
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.ContentType = "application/xml";
            response.WriteFile(HttpContext.Current.Server.MapPath("~/feed.xml"));
            response.Flush();
            response.End();
        }

    }

}