using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Inventory",
                url: "Inventory/Index/{id}",
                defaults: new { controller = "Inventory", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "HomeIndex",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { action= "Index|Contact|About|GenError"}
            );

            routes.MapRoute(
                name: "ServerError",
                url: "Error/ServerError",
                defaults: new { controller = "Error", action = "ServerError", id = UrlParameter.Optional }
            );

          

            //Catch all
            routes.MapRoute(
                name : "Not Found",
                url : "{*url}",
                defaults : new { controller = "Error", action = "NotFound" }
            );
        }
    }
}
