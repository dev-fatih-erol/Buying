using Buying.Application.Instructions.Responses;
using MediatR;

namespace Buying.Application.Instructions.Queries
{
    public class GetInstructionChannelsQuery : IRequest<List<ChannelResponse>>
    {
		public int InstructionId { get; }

		public GetInstructionChannelsQuery(int instructionId)
		{
            InstructionId = instructionId;
		}
	}
}