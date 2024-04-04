using MediatR;

namespace Buying.Application.Instructions.Notifications
{
    public class SendEmailNotification : INotification
    {
        public string UserName { get; }

        public string Email { get; }

        public decimal Amount { get; }

        public SendEmailNotification(string userName, string email, decimal amount)
        {
            UserName = userName;
            Email = email;
            Amount = amount;
        }
    }
}