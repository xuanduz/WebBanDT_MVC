using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Add to cart",
               url: "add-to-cart",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "WebDT.Controllers" }
           );

            routes.MapRoute(
               name: "Cart",
               url: "Cart",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "WebDT.Controllers" }
           );

            routes.MapRoute(
               name: "Payment",
               url: "payment",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "WebDT.Controllers" }
           );

            routes.MapRoute(
                name: "Product Detail",
                url: "detail/{nameProduct}-{memoryProduct}-{colorProduct}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "WebDT.Controllers" }
            );

            routes.MapRoute(
               name: "Register",
               url: "Register",
               defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "WebDT.Controllers" }
           );

            routes.MapRoute(
               name: "Login",
               url: "Login",
               defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "WebDT.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"WebDT.Controllers"}
            );
        }
    }
}
