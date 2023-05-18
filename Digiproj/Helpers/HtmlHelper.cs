using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using DigiProj.Helpers;
using DigiProj.Configuration.Constants;
using DigiProj.Shared.Dtos.Responses.MsUser;
using DigiProj.Shared.Entities.MsUser;

namespace DigiProj.Helpers
{
    public static class HtmlHelper
	{
		public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
		{
			var routeData = htmlHelper.ViewContext.RouteData;

			var routeAction = routeData.Values["action"].ToString();
			var routeController = routeData.Values["controller"].ToString();

			var returnActive = (routeController.Contains(controller, StringComparison.OrdinalIgnoreCase) && routeAction.Contains(action, StringComparison.OrdinalIgnoreCase));

			return returnActive ? "active" : "";
		}

		public static async Task SignOutCookieAsync(this HttpContext context)
		{
			context.DeleteCookies();

			await context.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme);
		}

		public static void Redirector(this HttpContext context, MsUser user, IEnumerable<UserMenusResponse> menus)
		{
			//Redirect force change password
			if (user.IsForceChangePassword)
			{
				context.Response.Redirect(context.GetUrl("/Account/ChangePassword"));
				return;
			}


			//Redirect menu not allowed
			var requestPath = context.Request.Path.Value;
			var requestPathBase = context.Request.PathBase.Value;
			if (!string.IsNullOrEmpty(requestPathBase))
				requestPath = requestPath.Replace(requestPathBase, "");

			if (requestPath != "/" && requestPath != "")
			{
				var allowedMenus = ConfigurationConsts.AllowedMenus.Any(x =>
					requestPath != null && requestPath.Contains(x, StringComparison.OrdinalIgnoreCase));
				if (!allowedMenus
					&& !menus.Any(menu => requestPath.Contains(menu.Action, StringComparison.OrdinalIgnoreCase)
										  && requestPath.Contains(menu.Controller, StringComparison.OrdinalIgnoreCase)))
				{
					context.Response.Redirect(context.GetUrl("/Home/AccessDenied"));
					return;
				}
			}

		}
	}
}
