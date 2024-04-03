using AutoMapper;
using Buying.Application.Common.Accessors;
using Buying.Application.Common.Exceptions;
using Buying.Application.Instructions.Queries;
using Buying.Application.Instructions.Responses;
using Buying.Infrastructure.Domain.Enums;
using Buying.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Buying.Application.Instructions.Handlers
{
    public class GetActiveInstructionHandler : IRequestHandler<GetActiveInstructionQuery, InstructionResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;
        private readonly ILogger<GetActiveInstructionHandler> _logger;

        public GetActiveInstructionHandler(ApplicationDbContext dbContext,
            IUserAccessor userAccessor,
            IMapper mapper,
            ILogger<GetActiveInstructionHandler> logger)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InstructionResponse> Handle(GetActiveInstructionQuery request, CancellationToken cancellationToken)
        {
            var instruction = await _dbContext.Instructions
                .Where(i => i.InstructionStatus == InstructionStatus.Active && i.UserId == _userAccessor.UserId)
                .SingleOrDefaultAsync(cancellationToken);

            if (instruction == null)
                throw new NotFoundException("Active instruction not found.");

            var response = _mapper.Map<InstructionResponse>(instruction);

            return response;
        }
    }
}