using Buying.Application.Instructions.Notifications;
using MediatR;

namespace Buying.Application.Instructions.Handlers
{
    public class BuyingCompletedHandler : INotificationHandler<SendSmsNotification>,
                                          INotificationHandler<SendEmailNotification>,
                                          INotificationHandler<SendPushNotification>
 
    {
        public async Task Handle(SendSmsNotification notification, CancellationToken cancellationToken)
        {
            var phoneNumber = notification.PhoneNumber;
            var text = $"Dear {notification.UserName}, Your gold purchase has been completed at a rate of {notification.Amount} units today. " +
                $"We thank you for this transaction. Have a great day.";

            /// Please add the necessary code for sending SMS here. ///
            ///// SAMPLE CODE /////
            ////// _smsSender.Send(phoneNumber, text); //////

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
            
            await Task.Delay(1000, cancellationToken);
        }
    }
}