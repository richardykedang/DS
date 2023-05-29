using AspNetCoreHero.ToastNotification;
using DigiProj.Configuration.Constants;
using DigiProj.Infrastructure.Middlewares;
using DigiProj.Services;
using DigiProj.Shared.Configuration.Constants;
using DigiProj.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Globalization;
namespace DigiProj.Helpers
{
	public static class StartupHelper
	{
		public static IServiceCollection AddAndConfigureAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(options => options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
				{
					options.Cookie.SameSite = SameSiteMode.Strict;
					options.SlidingExpiration = true;
				});

			return services;
		}
		public static IServiceCollection AddAndConfigureOptions(this IServiceCollection services)
		{
			CultureInfo.DefaultThreadCurrentCulture = DefaultConsts.DefaultCulture;
			CultureInfo.DefaultThreadCurrentUICulture = DefaultConsts.DefaultCulture;

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			return services;
		}
		public static IServiceCollection AddAndConfigureScoped(this IServiceCollection services)
		{
			services.AddNotyf(config => { config.DurationInSeconds = 6; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAuthenticationApiService, AuthenticationApiService>();
            services.AddScoped<IUserApiService, UserApiService>();
			services.AddScoped<IProjectApiService, ProjectApiService>();
			services.AddScoped<IDepartmentService, DepartmentApiService>();
            services.AddScoped<ITaskApiService, TaskApiService>();
            services.AddScoped<IMenuApiService, MenuApiService>();


            services.AddHttpContextAccessor();

			return services;
		}

		public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
		{
			app.Use(async (context, next) =>
			{
				await next();
				switch (context.Response.StatusCode)
				{
					case StatusCodes.Status404NotFound:
						context.Request.Path = "/Home/PageNotFound";
						await next();
						break;
					case StatusCodes.Status500InternalServerError:
						context.Request.Path = "/Home/InternalServerError";
						await next();
						break;
					case StatusCodes.Status503ServiceUnavailable:
						context.Request.Path = "/Home/Maintenance";
						await next();
						break;
				}
			});

			app.UseMiddleware<DataDependenciesMiddleware>();
			//app.UseMiddleware<MaintenanceMiddleware>();

			return app;
		}

		public static bool SkipMiddleware(this HttpContext context)
		{
			var skipPaths = ConfigurationConsts.SkipMiddlewarePaths.Any(x =>
				context.Request.Path.Value != null && context.Request.Path.Value.Contains(x));

			var skipStaticFiles = ConfigurationConsts.StaticFileExtensions.Any(x =>
				context.Request.Path.Value != null && context.Request.Path.Value.Contains(x));

			return skipPaths || skipStaticFiles;
		}

		public static bool DetectMobileBrowsers(this HttpContext context)
		{
			//http://detectmobilebrowsers.com/

			var userAgentKey = "User-Agent";
			var userAgent = context.Request.Headers[userAgentKey].ToString();

			if (userAgent != null)
			{
				if (userAgent.Length < 4)
					return false;

				if (ConfigurationConsts.MobileCheck.IsMatch(userAgent) || ConfigurationConsts.MobileVersionCheck.IsMatch(userAgent.Substring(0, 4)))
					return true;
			}

			return false;
		}
	}
}
