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
                "RouteDetailsWithId",
                "{controller}/Details/{id}",
                new { controller = "NewsItemDbShow", action="Details", id = UrlParameter.Optional},
                new { id = @"\d+" }
            );
            routes.MapRoute(
                "RouteWithNoId",
                "{controller}/{action}",
                new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index"}
            );
        }
    }
}