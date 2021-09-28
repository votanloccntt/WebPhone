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
            routes.IgnoreRoute("{*botdetect}",
    new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
            routes.MapRoute(
                name: "Add Cart",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
            routes.MapRoute(
                name: "Contact",
                url: "lien-he",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
            );
            routes.MapRoute(
              name: "Cart",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
           );
            routes.MapRoute(
              name: "Payment",
              url: "thanh-toan",
              defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
           );
            routes.MapRoute(
              name: "Payment Success",
              url: "hoan-thanh",
              defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional }, namespaces: new[] { "WebPhone.Controllers" }
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