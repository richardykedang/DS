using DigiProj.Configuration.Constants;
using DigiProj.Helpers;
using DigiProj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Diagnostics;

namespace DigiProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Dashboard";

            return View();
        }

		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			var model = GetErrorViewModel();

            //Error tanpa layout base
            if (User.Identity?.IsAuthenticated == false ||
				model.ErrorDescription == ConfigurationConsts.ErrorMessageUnableConnectApi)
				return View(nameof(InternalServerError), model);

			return View(model);
		}

		[AllowAnonymous]
		public IActionResult InternalServerError()
		{
			return View(GetErrorViewModel());
		}

		[AllowAnonymous]
		public IActionResult Maintenance()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult AccessDenied()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult AccessFromMobile()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult PageNotFound()
		{
			return View();
		}

		private ErrorViewModel GetErrorViewModel()
		{
			var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
			HttpContext.Response.StatusCode = StatusCodes.Status200OK;
			var model = new ErrorViewModel();
			if (exception != null)
			{
				var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
				model = new ErrorViewModel { RequestId = requestId, RequestPath = exception.Path, ErrorDescription = exception.Error.Message };
				Log.Error(exception.Error, $"{requestId} {exception.Path}");
			}

			return model;
		}

	}
}