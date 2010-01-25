using System.Web.Mvc;
using System.Web.Routing;

namespace Project.Core.Lib.Infrastructure
{
    public static class RouteRegistrar
    {
        public const string DefaultAction = "Index";

        public const string DefaultController = "Contacts";

        public static string[] DefaultRoutes = new[] { "~/", "~/default.aspx", "~/default.asp", "~/index.htm", "~/index.html" };

        /// <remarks>
        /// Using the principle of least required information, nested routes are required for 
        /// Create, New, and Index actions. Delete, Edit, Show, and Update actions have a 
        /// reference to the resource ID directly.
        /// '/Contacts/1/Notes/2/Edit' and 'Notes/2/Edit' point to the same resource.
        /// </remarks>        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            // Nested route for Contacts/Notes
            routes.MapRoute("CreateNote", "Contacts/{contactId}/Notes", new { controller = "Notes", action = "Create", contactId = 0 }, new { contactId = @"\d+", method = new HttpMethodConstraint("POST") });
            routes.MapRoute("NewNote", "Contacts/{contactId}/Notes/New", new { controller = "Notes", action = "New", contactId = 0 }, new { contactId = @"\d+", method = new HttpMethodConstraint("GET") });
            routes.MapRoute("IndexNotes", "Contacts/{contactId}/Notes", new { controller = "Notes", action = "Index", contactId = 0 }, new { contactId = @"\d+", method = new HttpMethodConstraint("GET") });

            // RESTful resource-style mapping
            routes.MapRoute("CreateResource", "{controller}", new { controller = DefaultController, action = "Create", id = string.Empty }, new { method = new HttpMethodConstraint("POST") });
            routes.MapRoute("DeleteResource", "{controller}/{id}", new { controller = DefaultController, action = "Delete", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("DELETE") });
            routes.MapRoute("EditResource", "{controller}/{id}/Edit", new { controller = DefaultController, action = "Edit", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("GET") });
            routes.MapRoute("IndexResource", "{controller}", new { controller = DefaultController, action = "Index", id = string.Empty }, new { method = new HttpMethodConstraint("GET") });
            routes.MapRoute("NewResource", "{controller}/New", new { controller = DefaultController, action = "New", id = 0 }, new { method = new HttpMethodConstraint("GET") });
            routes.MapRoute("ShowResource", "{controller}/{id}", new { controller = DefaultController, action = "Show", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("GET") });
            routes.MapRoute("UpdateResource", "{controller}/{id}", new { controller = DefaultController, action = "Update", string.Empty }, new { id = @"\d+", method = new HttpMethodConstraint("PUT") });

            // Default route
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = DefaultController, action = DefaultAction, id = 0 });
        }
    }
}
