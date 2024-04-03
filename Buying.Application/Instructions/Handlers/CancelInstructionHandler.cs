using Buying.Application.Common.Accessors;
using Buying.Application.Common.Exceptions;
using Buying.Application.Instructions.Commands;
using Buying.Infrastructure.Domain.Enums;
using Buying.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Buying.Application.Instructions.Handlers
{
    public class CancelInstructionHandler : IRequestHandler<CancelInstructionCommand, Unit>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        private readonly ILogger<CancelInstructionHandler> _logger;

        public CancelInstructionHandler(ApplicationDbContext dbContext,
            IUserAccessor userAccessor,
            ILogger<CancelInstructionHandler> logger)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
            _logger = logger;
        }

        public async Task<Unit> Handle(CancelInstructionCommand request, CancellationToken cancellationToken)
        {
            var instruction = await _dbContext.Instructions
                .Where(i => i.InstructionStatus == InstructionStatus.Active && i.UserId == _userAccessor.UserId)
                .SingleOrDefaultAsync(cancellationToken);

            if (instruction == null)
                throw new NotFoundException("Active instruction not found.");

            instruction.InstructionStatus = InstructionStatus.Cancelled;
            await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Instruction successfully cancelled. Id:{instruction.Id}");

            return Unit.Value;
        }
    }
}