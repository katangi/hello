using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "MyCustomer", id = UrlParameter.Optional }).DataTokens.Add("area", "Customer");
              // defaults: new { controller = "Partial", action = "Index", id = UrlParameter.Optional });
                //);
        }
    }
}