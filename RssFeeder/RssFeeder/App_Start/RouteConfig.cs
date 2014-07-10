using System.Web.Mvc;
using System.Web.Routing;

namespace RssFeeder.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "XmlStream",
                url: "XmlStreamFeed/{feedType}/{noOfFeeds}",
                defaults: new { controller = "Feed", action = "XmlStreamFeed", feedType = "rss", noOfFeeds = "10" }
            );
            routes.MapRoute(
                name: "XmlFile",
                url: "XmlFileFeed/{feedType}/{noOfFeeds}",
                defaults: new { controller = "Feed", action = "XmlFileFeed", feedType = "rss", noOfFeeds = "10" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}