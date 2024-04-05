using MediatR;

namespace Buying.Application.Instructions.Notifications
{
    public class SendSmsNotification : INotification
    {
        public int Id { get; }

        public string UserName { get; }

        public string PhoneNumber { get; }

        public decimal Amount { get; }

        public SendSmsNotification(int id, string userName, string phoneNumber, decimal amount)
		{
            Id = id;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Amount = amount;
        }
	}
}