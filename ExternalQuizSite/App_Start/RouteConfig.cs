using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExternalQuizSite {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) { 

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "QuizSelection", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Quiz",
                url: "Quiz",
                defaults: new { controller = "Home", action = "Quiz", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Score",
                url: "Quiz/Score",
                defaults: new { controller = "Home", action = "Score", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SuperSecret",
                url: "SuperSecret/SuperSecret/SuperSecret/{id}",
                defaults: new { controller = "Home", action = "SuperSecret", id = UrlParameter.Optional }
            );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
