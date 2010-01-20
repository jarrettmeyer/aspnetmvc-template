using System.Web.Mvc;
using System.Web.Routing;

namespace Project.Core.Lib.Infrastructure
{
    public static class RouteRegistrar
    {
        public const string DefaultAction = "Index";

        public const string DefaultController = "Home";

        public static string[] DefaultRoutes = new[] { "~/", "~/default.aspx", "~/default.asp", "~/index.htm", "~/index.html" };

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // RESTful resource-style mapping
            routes.MapRoute("CreateResource", "{controller}", new { controller = DefaultController, action = "Create", id = string.Empty }, new { method = new HttpMethodConstraint("POST") });
            routes.MapRoute("DeleteResource", "{controller}/{id}", new { controller = DefaultController, action = "Delete", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("DELETE", "POST") });
            routes.MapRoute("EditResource", "{controller}/{id}/Edit", new { controller = DefaultController, action = "Edit", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("GET") });
            routes.MapRoute("IndexResource", "{controller}", new { controller = DefaultController, action = "Index", id = string.Empty }, new { method = new HttpMethodConstraint("GET") });
            routes.MapRoute("NewResource", "{controller}/New", new { controller = DefaultController, action = "New", id = 0 }, new { method = new HttpMethodConstraint("GET") });
            routes.MapRoute("ShowResource", "{controller}/{id}", new { controller = DefaultController, action = "Show", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("GET") });
            routes.MapRoute("UpdateResource", "{controller}/{id}", new { controller = DefaultController, action = "Update", string.Empty }, new { id = @"\d+", method = new HttpMethodConstraint("POST", "PUT") });
        }
    }
}
