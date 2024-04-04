using Buying.Application.Common.Constants;
using Buying.Application.Common.Extensions;
using Buying.Application.Instructions.Commands;
using Buying.Application.Instructions.Events;
using Buying.Application.Instructions.Notifications;
using Buying.Infrastructure.Persistence;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Buying.Application.Instructions.Handlers
{
    public class BuyingStartedHandler : IRequestHandler<BuyingStartedCommand, Unit>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IMessageScheduler _messageScheduler;

        public BuyingStartedHandler(ApplicationDbContext dbContext,
            IMediator mediator,
            IMessageScheduler messageScheduler)
        {
            _dbContext = dbContext;
            _mediator = mediator;
            _messageScheduler = messageScheduler;
        }

        public async Task<Unit> Handle(BuyingStartedCommand request, CancellationToken cancellationToken)
        {
            /***************************************
             *                                      *
             * Buying operation occurs here         *
             *                                      *
             ***************************************/

            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            foreach (var channel in request.Channels)
            {
                switch (channel)
                {
                    case Channels.SMS:
                        await _mediator.Publish(new SendSmsNotification(user.UserName, user.PhoneNumber, request.Amount), cancellationToken);
                        break;
                    case Channels.Email:
                        await _mediator.Publish(new SendEmailNotification(user.UserName, user.Email, request.Amount), cancellationToken);
                        break;
                    case Channels.PushNotification:
                        await _mediator.Publish(new SendPushNotification(user.UserName, "Sample_Device_Token", request.Amount), cancellationToken);
                        break;
                    default:
                        throw new ArgumentException($"Invalid channel: {channel}");
                }
            }

            var now = request.ExecutionDay.ToExecutionDate();
            await _messageScheduler.SchedulePublish<InstructionCreatedEvent>(DateTime.UtcNow + TimeSpan.FromSeconds(30), new
            {
                request.Id,
                request.Amount,
                request.ExecutionDay,
                request.Channels,
                request.UserId
            }, cancellationToken);

            return Unit.Value;
        }
    }
}