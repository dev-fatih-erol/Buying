using Buying.Application.Instructions.Responses;
using MediatR;

namespace Buying.Application.Instructions.Queries
{
    public class GetActiveInstructionQuery : IRequest<InstructionResponse>
    {
		public GetActiveInstructionQuery()
		{}
	}
}