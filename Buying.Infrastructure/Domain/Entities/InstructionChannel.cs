namespace Buying.Infrastructure.Domain.Entities
{
    public class InstructionChannel
    {
        public int InstructionId { get; set; }

        public int ChannelId { get; set; }

        #region Relations

        public Instruction Instruction { get; set; }

        public Channel Channel { get; set; }

        #endregion
    }
}