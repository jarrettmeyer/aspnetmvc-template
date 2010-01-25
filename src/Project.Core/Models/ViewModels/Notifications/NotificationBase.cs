namespace Project.Core.Models.ViewModels.Notifications
{
    public abstract class NotificationBase : INotification
    {
        private readonly string _message;

        protected NotificationBase(string message)
        {
            _message = message;
        }

        public virtual string Message
        {
            get { return _message; }
        }
    }
}