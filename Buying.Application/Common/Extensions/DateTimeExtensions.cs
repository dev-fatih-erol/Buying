namespace Buying.Application.Common.Extensions
{
    public static class DateTimeExtensions
	{
		public static DateTime ToExecutionDate(this int executionDay)
		{
            var currentDate = DateTime.UtcNow;

            var executionDate = new DateTime(currentDate.Year, currentDate.Month, executionDay);

            if (executionDate < currentDate)
                executionDate = executionDate.AddMonths(1);

            return executionDate;
        }
	}
}