using System.Collections.Generic;
using System.Linq;

namespace Project.Core.Models.ViewModels.Notifications
{
    public static class NotificationExtensions
    {
        public static bool HasNotifications(this IEnumerable<INotification> notifications)
        {
            return notifications.Any();
        }

        public static bool HasNotifications<T>(this IEnumerable<INotification> notifications) where T : INotification
        {
            return notifications.Any(n => n.GetType() == typeof(T));
        }

        public static IEnumerable<INotification> GetNotifications<T>(this IEnumerable<INotification> notifications) where T : INotification
        {
            return notifications.Where(n => n.GetType() == typeof(T));
        }
    }
}
