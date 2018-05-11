using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AzureAdDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action= "GetAllProducts" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { controller="Home", action = "Index", id = RouteParameter.Optional }
            //);
        }
    }
}
