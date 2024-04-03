namespace Buying.Application.Instructions.Responses
{
    public class InstructionResponse
	{
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int ExecutionDay { get; set; }

        public string InstructionStatus { get; set; }
    }
}