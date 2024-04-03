using System.Security.Claims;

namespace Buying.Application.Common.Accessors
{
    public interface IUserAccessor
	{
        int UserId { get; }

        ClaimsPrincipal User { get; }
    }
}