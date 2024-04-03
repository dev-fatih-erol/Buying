using Buying.Infrastructure.Domain.Enums;

namespace Buying.Infrastructure.Domain.Entities
{
    public class Instruction
	{
		public int Id { get; set; }

        public decimal Amount { get; set; }

        public int ExecutionDay { get; set; }

        public InstructionStatus InstructionStatus { get; set; }

        #region Relations

        public int UserId { get; set; }

        public User User { get; set; }

        public List<InstructionChannel> InstructionChannels { get; set; } = new List<InstructionChannel>();

        #endregion
    }
}