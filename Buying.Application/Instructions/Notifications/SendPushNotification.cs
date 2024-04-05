using MediatR;

namespace Buying.Application.Instructions.Notifications
{
    public class SendPushNotification : INotification
    {
        public int Id { get; }

        public string UserName { get; }

        public string DeviceToken { get; }

        public decimal Amount { get; }

        public SendPushNotification(int id, string userName, string deviceToken, decimal amount)
        {
            Id = id;
            UserName = userName;
            DeviceToken = deviceToken;
            Amount = amount;
        }
    }
}