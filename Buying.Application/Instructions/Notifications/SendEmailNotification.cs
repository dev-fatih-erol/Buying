using MediatR;

namespace Buying.Application.Instructions.Notifications
{
    public class SendEmailNotification : INotification
    {
        public int Id { get; }

        public string UserName { get; }

        public string Email { get; }

        public decimal Amount { get; }

        public SendEmailNotification(int id, string userName, string email, decimal amount)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Amount = amount;
        }
    }
}