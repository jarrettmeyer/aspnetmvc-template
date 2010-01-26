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

        public override bool Equals(object obj)
        {
            return Equals((NotificationBase)obj);
        }

        public bool Equals(NotificationBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._message, _message);
        }

        public override int GetHashCode()
        {
            return (_message != null ? _message.GetHashCode() : 0);
        }

        public static bool operator ==(NotificationBase left, NotificationBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NotificationBase left, NotificationBase right)
        {
            return !Equals(left, right);
        }
    }
}