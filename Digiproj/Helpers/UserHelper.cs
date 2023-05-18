using Digistrat.Shared.Configuration.Constants;
using Digistrat.Shared.Entities.MsUser;
using System.Security.Claims;

namespace Digistrat.Helpers
{
	public static class UserHelper
	{
		public static MsUser GetClaims(this ClaimsPrincipal user)
		{
			return new()
			{
				Name = user.FindFirstValue(JwtClaimTypeConsts.Name),
				Username = user.FindFirstValue(JwtClaimTypeConsts.PreferredUserName),
				LastLogin = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(user.FindFirstValue(JwtClaimTypeConsts.LastLogin))).DateTime.ToLocalTime(),
				IsForceChangePassword = Convert.ToBoolean(user.FindFirstValue(JwtClaimTypeConsts.IsForceChangePassword)),
			};
		}
	}
}
