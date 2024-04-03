namespace Buying.Infrastructure.Domain.Entities
{
    public class User
	{
		public int Id { get; set; }

		public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        #region Relations

        public List<Instruction> Instructions { get; set; } = new List<Instruction>();

        #endregion
    }
}