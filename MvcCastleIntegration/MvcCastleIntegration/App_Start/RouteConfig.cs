using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCastleIntegration
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Set the default MVC page to be the Test controller's Index action
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}