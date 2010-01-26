using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Project.Core.Models.ViewModels.Notifications;

namespace Project.Core.Lib.Infrastructure
{
    public class HttpAppScope : IAppScope
    {        
        private readonly HttpContextBase _httpContext;
        private readonly HttpSessionStateBase _session;

        public HttpAppScope(HttpContextBase httpContext)
        {
            Ensure.ArgumentNotNull(httpContext, "httpContext");
            _httpContext = httpContext;
            _session = httpContext.Session;
        }

        public bool IsNewSession
        {
            get { return _session.IsNewSession; }
        }

        public bool IsXhr
        {
            get { return _httpContext.Request.IsAjaxRequest(); }
        }

        public IEnumerable<INotification> Notifications
        {
            get { return GetNotificationsInternal(); }
        }

        public void AddError(string error)
        {
            var notifcation = new ErrorNotification(error);
            AddNotification(notifcation);
        }

        public void AddInfo(string info)
        {
            var notification = new InfoNotification(info);
            AddNotification(notification);
        }

        private void AddNotification(INotification notification)
        {
            Ensure.ArgumentNotNull(notification, "notification");
            var notifications = GetNotificationsInternal();
            if (!notifications.Contains(notification))
            {
                notifications.Add(notification);
                SetNotfications(notifications);
            }            
        }

        public void AddSuccess(string success)
        {
            var notification = new SuccessNotification(success);
            AddNotification(notification);
        }

        public void AddWarning(string warning)
        {
            var notification = new WarningNotification(warning);
            AddNotification(notification);
        }

        public void ClearNotifications()
        {
            _session[SessionKeys.Notifications] = null;
        }

        private ICollection<INotification> GetNotificationsInternal()
        {
            var notifications = (ICollection<INotification>)_session[SessionKeys.Notifications];
            return notifications ?? new List<INotification>();
        }

        private void SetNotfications(IEnumerable<INotification> notifications)
        {
            _session[SessionKeys.Notifications] = notifications;
        }

        private static class SessionKeys
        {
            internal const string Notifications = "Notifications";
        }
    }
}
