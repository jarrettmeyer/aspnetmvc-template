using Xunit;

namespace Project.Core.Models.ViewModels.Notifications
{
    public class SuccessNotificationTests
    {
        [Fact]
        public void CtorAssignsMessage()
        {
            const string msg = "My message";
            var success = new SuccessNotification(msg);
            Assert.Equal(msg, success.Message);
        }
    }
}
