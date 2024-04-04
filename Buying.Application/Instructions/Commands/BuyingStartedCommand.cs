using MediatR;

namespace Buying.Application.Instructions.Commands
{
    public class BuyingStartedCommand : IRequest<Unit>
	{
        public int Id { get; }

        public decimal Amount { get; }

        public int ExecutionDay { get; }

        public string[] Channels { get; }

        public int UserId { get; }

        public BuyingStartedCommand(int id, decimal amount, int executionDay, string[] channels, int userId)
        {
            Id = id;
            Amount = amount;
            ExecutionDay = executionDay;
            Channels = channels;
            UserId = userId;
        }
    }
}