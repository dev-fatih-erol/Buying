namespace Buying.Infrastructure.Domain.Entities
{
    public class Channel
	{
		public int Id { get; set; }

		public string Type { get; set; }

        #region Relations

        public List<InstructionChannel> InstructionChannels { get; set; } = new List<InstructionChannel>();

        #endregion
    }
}