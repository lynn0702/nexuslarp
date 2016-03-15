using System.Web.Mvc;
using System.Web.Routing;

namespace NexChar
{
    public class RouteRegistrar
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Application", action = "Index", id = @"\d*" });
        }
    }
}