using MediatR;

namespace Buying.Application.Instructions.Notifications
{
    public class SendSmsNotification : INotification
    {
        public string UserName { get; }

        public string PhoneNumber { get; }

        public decimal Amount { get; }

        public SendSmsNotification(string userName, string phoneNumber, decimal amount)
		{
            UserName = userName;
            PhoneNumber = phoneNumber;
            Amount = amount;
        }
	}
}