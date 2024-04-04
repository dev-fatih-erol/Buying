using Buying.Application.Instructions.Commands;
using Buying.Application.Instructions.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Buying.Application.Instructions.Consumers
{
    public class InstructionCreatedConsumer : IConsumer<InstructionCreatedEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InstructionCreatedConsumer> _logger;

        public InstructionCreatedConsumer(IMediator mediator,
            ILogger<InstructionCreatedConsumer> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<InstructionCreatedEvent> context)
        {
            var command = new BuyingStartedCommand(
                context.Message.Id,
                context.Message.Amount,
                context.Message.ExecutionDay,
                context.Message.Channels,
                context.Message.UserId);

            _logger.LogInformation("New buying started - Id: {0}, Amount: {1}, ExecutionDay: {2}, Channels: {3}, UserId: {4}",
                command.Id,
                command.Amount,
                command.ExecutionDay,
                string.Join(",", command.Channels),
                command.UserId);

            await _mediator.Send(command);
        }
    }
}