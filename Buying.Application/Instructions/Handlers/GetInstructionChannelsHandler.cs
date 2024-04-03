using AutoMapper;
using Buying.Application.Common.Accessors;
using Buying.Application.Common.Exceptions;
using Buying.Application.Instructions.Queries;
using Buying.Application.Instructions.Responses;
using Buying.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Buying.Application.Instructions.Handlers
{
    public class GetInstructionChannelsHandler : IRequestHandler<GetInstructionChannelsQuery, List<ChannelResponse>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;
        private readonly ILogger<GetInstructionChannelsHandler> _logger;

        public GetInstructionChannelsHandler(ApplicationDbContext dbContext,
            IUserAccessor userAccessor,
            IMapper mapper,
            ILogger<GetInstructionChannelsHandler> logger)
        {
            _dbContext = dbContext;
            _userAccessor = userAccessor;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ChannelResponse>> Handle(GetInstructionChannelsQuery request, CancellationToken cancellationToken)
        {
            var instruction = await _dbContext.Instructions
                .Include(i => i.InstructionChannels)
                .ThenInclude(i => i.Channel)
                .Where(i => i.Id == request.InstructionId && i.UserId == _userAccessor.UserId)
                .SingleOrDefaultAsync(cancellationToken);

            if (instruction == null)
                throw new NotFoundException("Instruction not found.");

            var channels = instruction.InstructionChannels.Select(ic => ic.Channel).ToList();

            var response = _mapper.Map<List<ChannelResponse>>(channels);

            return response;
        }
    }
}