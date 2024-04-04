using Buying.Application.Common.Accessors;
using Buying.Application.Common.Exceptions;
using Buying.Application.Common.Extensions;
using Buying.Application.Instructions.Commands;
using Buying.Application.Instructions.Events;
using Buying.Infrastructure.Domain.Entities;
using Buying.Infrastructure.Domain.Enums;
using Buying.Infrastructure.Persistence;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Buying.Application.Instructions.Handlers
{
    public class CreateInstructionHandler : IRequestHandler<CreateInstructionCommand, Unit>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        private readonly IMessageScheduler _messageScheduler;
        private readonly ILogger<CreateInstructionHandler> _logger;

        public CreateInstructionHandler(ApplicationDbContext dbContext,
            IUserAccessor userAccessor,
            IMessageScheduler messageScheduler,
            ILogger<CreateInstructionHandler> logger)
		{
            _dbContext = dbContext;
            _userAccessor = userAccessor;
            _messageScheduler = messageScheduler;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateInstructionCommand request, CancellationToken cancellationToken)
        {
            var channels = await _dbContext.Channels.Where(c => request.ChannelIds.Any(i => i == c.Id))
                .ToListAsync(cancellationToken);

            if (!channels.Any())
                throw new NotFoundException("No channels found for the selected Ids.");

            var isExistActiveInstruction = await _dbContext.Instructions
                .AnyAsync(i => i.InstructionStatus == InstructionStatus.Active, cancellationToken);

            if (isExistActiveInstruction)
                throw new BadRequestException("There is already an active instruction.");

            var instruction = new Instruction
            {
                Amount = request.Amount,
                ExecutionDay = request.ExecutionDay,
                InstructionStatus = InstructionStatus.Active,
                UserId = _userAccessor.UserId,
                InstructionChannels = channels.Select(channel => new InstructionChannel
                {
                    Channel = channel
                }).ToList()
            };

            await _dbContext.Instructions.AddAsync(instruction, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var now = instruction.ExecutionDay.ToExecutionDate();
            await _messageScheduler.SchedulePublish<InstructionCreatedEvent>(DateTime.UtcNow + TimeSpan.FromSeconds(30), new
                {
                    instruction.Id,
                    instruction.Amount,
                    instruction.ExecutionDay,
                    channels = channels.Select(c => c.Type).ToArray(),
                    instruction.UserId
                }, cancellationToken);

            _logger.LogInformation($"Instruction created successfully. Id:{instruction.Id}");

            return Unit.Value;
        }
    }
}