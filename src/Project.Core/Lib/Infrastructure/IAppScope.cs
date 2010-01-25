using System.Collections.Generic;
using Project.Core.Models.ViewModels.Notifications;

namespace Project.Core.Lib.Infrastructure
{
    /// <summary>
    /// Provides an application level wrapper for resources. Allows for a separation
    /// from other intrinsic objects such as HttpContext, HttpRequest, HttpSessionState,
    /// Caching, etc. Undoing the binding between your business objects and those
    /// Framework objects makes for very difficult testing.
    /// </summary>
    public interface IAppScope
    {
        bool IsNewSession { get; }
        bool IsXhr { get; }
        IEnumerable<INotification> Notifications { get; }

        void AddError(string error);
        void AddInfo(string info);
        void AddSuccess(string success);
        void AddWarning(string warning);
        void ClearNotifications();
    }
}
