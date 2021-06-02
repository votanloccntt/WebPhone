using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebPhone
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
            routes.MapRoute(
                name: "Category",
                url: "danh-muc/{MetaTitle}-{categoryID}",
                defaults: new { controller = "Category", action = "CategoryDetail", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
            routes.MapRoute(
                name: "Product",
                url: "san-pham/{MetaTitle}-{productID}",
                defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
        }
    }
}