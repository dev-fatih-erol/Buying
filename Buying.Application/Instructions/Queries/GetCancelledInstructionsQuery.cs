using Buying.Application.Instructions.Responses;
using MediatR;

namespace Buying.Application.Instructions.Queries
{
    public class GetCancelledInstructionsQuery : IRequest<List<InstructionResponse>>
    {
		public decimal? MinAmount { get; }

        public decimal? MaxAmount { get; }

        public GetCancelledInstructionsQuery(decimal? minAmount, decimal? maxAmount)
		{
            MinAmount = minAmount;
            MaxAmount = maxAmount;
		}
	}
}