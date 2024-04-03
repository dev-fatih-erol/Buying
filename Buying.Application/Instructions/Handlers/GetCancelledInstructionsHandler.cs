using AutoMapper;
using Buying.Application.Common.Accessors;
using Buying.Application.Instructions.Queries;
using Buying.Application.Instructions.Responses;
using Buying.Infrastructure.Domain.Enums;
using Buying.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Buying.Application.Instructions.Handlers
{
    public class GetCancelledInstructionsHandler : IRequestHandler<GetCancelledInstructionsQuery, List<InstructionResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCancelledInstructionsHandler> _logger;

        public GetCancelledInstructionsHandler(ApplicationDbContext dbContext,
            IUserAccessor userAccessor,
            IMapper mapper,
            ILogger<GetCancelledInstructionsHandler> logger)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<InstructionResponse>> Handle(GetCancelledInstructionsQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Instructions.AsQueryable();

            if (request.MinAmount.HasValue && request.MaxAmount.HasValue)
                query = query.Where(i => i.Amount >= request.MinAmount.Value && i.Amount <= request.MaxAmount.Value);
            else if (request.MinAmount.HasValue)
                query = query.Where(i => i.Amount >= request.MinAmount.Value);
            else if (request.MaxAmount.HasValue)
                query = query.Where(i => i.Amount <= request.MaxAmount.Value);

            var instructions = await query.Where(i => i.InstructionStatus == InstructionStatus.Cancelled && i.UserId == _userAccessor.UserId)
                .OrderBy(i => i.Amount)
                .ToListAsync(cancellationToken);

            var response = _mapper.Map<List<InstructionResponse>>(instructions);

            return response;
        }
    }
}