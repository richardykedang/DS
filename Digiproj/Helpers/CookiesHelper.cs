using DigiProj.Configuration.Constants;
using DigiProj.Helpers;
using DigiProj.Shared.Dtos.Responses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;

namespace DigiProj.Helpers
{
	public static class CookiesHelper
	{
		public static readonly CookieOptions CookieOptions = new()
		{
			Secure = false,
			HttpOnly = true,
			SameSite = SameSiteMode.Strict
		};

		public static IResponseCookies SaveToken(this IResponseCookies cookies, TokenResponse token)
		{
			cookies.Append(ApiConsts.TokenPrefix + nameof(token.Token), SecurityHelper.GetCookiesEncrypted(token.Token), CookieOptions);
			cookies.Append(ApiConsts.TokenPrefix + nameof(token.RefreshToken), SecurityHelper.GetCookiesEncrypted(token.RefreshToken), CookieOptions);
			cookies.Append(ApiConsts.TokenPrefix + nameof(token.ExpiredTime), SecurityHelper.GetCookiesEncrypted(token.ExpiredTime.AddMinutes(-5).ToString()), CookieOptions);

			return cookies;
		}

		public static HttpContext DeleteCookies(this HttpContext context)
		{
			foreach (var cookie in context.Request.Cookies.Keys)
			{
				context.Response.Cookies.Delete(cookie);
			}
			return context;
		}

		public static TokenResponse GetToken(this HttpContext context)
		{
			TokenResponse token = null;
			if (context.Request.Cookies.AuthExists() == false)
				return token;

			try
			{
				token = new TokenResponse()
				{
					Token = SecurityHelper.GetCookiesDecrypted(context.Request.Cookies[ApiConsts.TokenPrefix + nameof(TokenResponse.Token)]),
					RefreshToken = SecurityHelper.GetCookiesDecrypted(context.Request.Cookies[ApiConsts.TokenPrefix + nameof(TokenResponse.RefreshToken)]),
					ExpiredTime = Convert.ToDateTime(SecurityHelper.GetCookiesDecrypted(context.Request.Cookies[ApiConsts.TokenPrefix + nameof(TokenResponse.ExpiredTime)]))
				};
			}
			catch (Exception e)
			{
				Log.Error("GetToken", e);
			}

			return token;
		}

		public static bool AuthExists(this IRequestCookieCollection cookies)
		{
			var authCookie = cookies[ApiConsts.TokenPrefix + CookieAuthenticationDefaults.AuthenticationScheme];
			return authCookie != null;
		}

		public static string GetUrl(this HttpContext context, string location)
		{
			var pathBase = context.Request.PathBase;
			var url = string.IsNullOrEmpty(pathBase) ? $"/{location}" : $"../../{pathBase}/{location}";

			return url.Replace("//", "/");
		}
	}
}
