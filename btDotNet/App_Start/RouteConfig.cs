using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace btDotNet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "NewsItemDbDetailsWithId",
                "NewsItemDbShow/Details/{id}",
                new { controller = "NewsItemDbShow", action="Details", id = UrlParameter.Optional},
                new { id = @"\d+" }
            );
            routes.MapRoute(
                "NewsItemDbWithNoId",
                "NewsItemDbShow/{action}",
                new { controller = "NewsItemDbShow", action = "Index" }
            );
            routes.MapRoute(
                "NewsItemDbDefault",
                "NewsItemDbShow",
                new { controller = "NewsItemDbShow", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index"}
            );
        }
    }
}