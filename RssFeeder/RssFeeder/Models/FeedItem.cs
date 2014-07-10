using System;

namespace RssFeeder.Models
{
    public class FeedItem
    {
        public string Title { get; set; }
        public DateTime FeedDate { get; set; }
        public string Summary { get; set; }
        public string FeedUrl { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
    }
}
