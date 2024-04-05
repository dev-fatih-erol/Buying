using Buying.Application.Common.Constants;
using Buying.Application.Instructions.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Buying.Application.Instructions.Handlers
{
    public class BuyingCompletedHandler : INotificationHandler<SendSmsNotification>,
                                          INotificationHandler<SendEmailNotification>,
                                          INotificationHandler<SendPushNotification>
 
    {
        private readonly ILogger<BuyingCompletedHandler> _logger;

        public BuyingCompletedHandler(ILogger<BuyingCompletedHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(SendSmsNotification notification, CancellationToken cancellationToken)
        {
            var phoneNumber = notification.PhoneNumber;
            var text = $"Dear {notification.UserName}, Your gold purchase has been completed at a rate of {notification.Amount} units today. " +
                $"We thank you for this transaction. Have a great day.";

            /// Please add the necessary code for sending SMS here. ///
            ///// SAMPLE CODE /////
            ////// _smsSender.Send(phoneNumber, text); //////

            _logger.LogInformation($"Instruction Id: {notification.Id}, Channel: {Channels.SMS}, CreatedAt: {DateTime.UtcNow}, Text: {text}");

            await Task.Delay(1000, cancellationToken);
        }

        public async Task Handle(SendEmailNotification notification, CancellationToken cancellationToken)
        {
            var email = notification.Email;
            var body = $"Dear {notification.UserName}, Your gold purchase has been completed at a rate of {notification.Amount} units today. " +
                $"We thank you for this transaction. Have a great day.";

            /// Please add the necessary code for sending E-mail here. ///
            ///// SAMPLE CODE /////
            ////// _emailSender.Send(email, body); //////

            _logger.LogInformation($"Instruction Id: {notification.Id}, Channel: {Channels.Email}, CreatedAt: {DateTime.UtcNow}, Body: {body}");

            await Task.Delay(1000, cancellationToken);
        }

        public async Task Handle(SendPushNotification notification, CancellationToken cancellationToken)
        {
            var deviceToken = notification.DeviceToken;
            var text = $"Dear {notification.UserName}, Your gold purchase has been completed at a rate of {notification.Amount} units today. " +
                $"We thank you for this transaction. Have a great day.";

            /// Please add the necessary code for sending Push Notification here. ///
            ///// SAMPLE CODE /////
            ////// _pushNotificationSender.Send(deviceToken, text); //////

            _logger.LogInformation($"Instruction Id: {notification.Id}, Channel: {Channels.PushNotification}, CreatedAt: {DateTime.UtcNow}, Text: {text}");

            await Task.Delay(1000, cancellationToken);
        }
    }
}