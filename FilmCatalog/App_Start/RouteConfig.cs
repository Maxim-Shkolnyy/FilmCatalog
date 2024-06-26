﻿using System.Web.Mvc;
using System.Web.Routing;

namespace FilmCatalog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /*
            routes.MapRoute(
                name: "Api",
                url: "api/{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional });
            */
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Films", action = "Index", id = UrlParameter.Optional }
            );      
        }
    }
}
