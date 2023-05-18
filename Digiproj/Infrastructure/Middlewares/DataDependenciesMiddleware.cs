using AutoMapper;
using DigiProj.Configuration;
using DigiProj.Helpers;
using DigiProj.Configuration;
using DigiProj.Helpers;
using DigiProj.Services.Interfaces;

namespace DigiProj.Infrastructure.Middlewares
{
	public class DataDependenciesMiddleware
	{
		private readonly RequestDelegate _next;

		public DataDependenciesMiddleware(RequestDelegate next)
		{
			if (next == null)
			{
				throw new ArgumentNullException("next");
			}
			_next = next;
		}

		public async Task Invoke(HttpContext context, IUserApiService apiService, IMapper mapper, IConfiguration configuration)
		{
			if (context.SkipMiddleware())
			{
				await _next(context);
				return;
			}

			//Detect access from mobile browsers is not allowed
			//Ada juga validasi di js _layout.cshtml
			//if (context.DetectMobileBrowsers())
			//{
			//	context.Response.Redirect(context.GetUrl("Home/AccessFromMobile"));
			//	await _next(context);
			//	return;
			//}

			//Security keys
			if (!SecurityHelper.IsAdded)
				configuration.AddSecurityKeys();

			//Check Api Connection
			var apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
			apiConfig.CheckConnection();


			if (context.Request.Cookies.AuthExists())
			{
				//Token
				//Prevent many redirect
				var redirectUrl = "/Account/Login";
				if (context.Request.Path != redirectUrl)
				{
					if (context.GetToken() == null)
					{
						await context.SignOutCookieAsync();
						context.Response.Redirect(context.GetUrl(redirectUrl));

						return;
					}
				}

				////System Control 
				//if (!UserHelper.IsAdded || UserHelper.BODDate != DateTime.Today)
				//{
				//    var apiResponseDto = await apiService.GetSystemControlAsync();
				//    var apiResponse = mapper.Map<SystemControl>(apiResponseDto.Data);

				//    apiResponse.AddSystemControl();
				//}
			}


			await _next(context);
		}
	}
}
