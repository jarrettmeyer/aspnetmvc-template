using System.Web.Mvc;
using Project.Core.Lib.Infrastructure;

namespace Project.Core.Controllers
{
    public class NotificationsController : ApplicationController
    {
        public NotificationsController(IAppScope appScope)
            : base(appScope)
        {
        }

        public ActionResult Index()
        {
            var notifications = _appScope.Notifications;
            _appScope.ClearNotifications();            
            return PartialView(notifications);            
        }

        protected override void OnControllerCreated()
        {            
        }
    }
}
