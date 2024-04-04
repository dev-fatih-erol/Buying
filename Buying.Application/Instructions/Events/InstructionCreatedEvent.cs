namespace Buying.Application.Instructions.Events
{
    public class InstructionCreatedEvent
	{
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int ExecutionDay { get; set; }

        public int[] ChannelIds { get; set; }

        public int UserId { get; set; }
    }
}