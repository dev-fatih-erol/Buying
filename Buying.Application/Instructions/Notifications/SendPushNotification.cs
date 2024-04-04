using MediatR;

namespace Buying.Application.Instructions.Notifications
{
    public class SendPushNotification : INotification
    {
        public string UserName { get; }

        public string DeviceToken { get; }

        public decimal Amount { get; }

        public SendPushNotification(string userName, string deviceToken, decimal amount)
        {
            UserName = userName;
            DeviceToken = deviceToken;
            Amount = amount;
        }
    }
}