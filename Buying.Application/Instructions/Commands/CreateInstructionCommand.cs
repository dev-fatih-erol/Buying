using MediatR;

namespace Buying.Application.Instructions.Commands
{
    public class CreateInstructionCommand : IRequest<Unit>
    {
        public decimal Amount { get; }

        public int ExecutionDay { get; }

        public int[] ChannelIds { get; }

        public CreateInstructionCommand(decimal amount, int executionDay, int[] channelIds)
        {
            Amount = amount;
            ExecutionDay = executionDay;
            ChannelIds = channelIds;
        }
    }
}