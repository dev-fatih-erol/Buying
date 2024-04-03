namespace Buying.Application.Instructions.Requests
{
    public class CreateInstructionRequest
	{
        public decimal Amount { get; set; }

        public int ExecutionDay { get; set; }

        public int[] ChannelIds { get; set; }
    }
}