using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Obalon
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(name: "Patient2",
            //    url: "Patient2/{action}/{name}",
            //    defaults: new { controller = "Patient2", action = "index", name=UrlParameter.Optional });


            routes.MapRoute(
              name: "Patient",
              url: "Patient/{action}/{name}",
              defaults: new { controller = "Patient", action = "Index", name=UrlParameter.Optional}
          );
            routes.MapRoute(
              name: "PatientDetails",
              url: "Patient/{action}/{id}",
              defaults: new { controller = "Patient", action = "Details", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
