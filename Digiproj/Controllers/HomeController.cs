using AutoMapper;
using Digiproj.Shared.Dtos.Requests;
using DigiProj.Configuration.Constants;
using DigiProj.Helpers;
using DigiProj.Models;
using DigiProj.Models.Project;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses.MsTask;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Diagnostics;
using System.Threading;

namespace DigiProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
		private readonly IMenuApiService _apiMenuService;
        private readonly ITaskApiService _apiTaskService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IConfiguration config,IMapper mapper ,IMenuApiService menuApiService,ITaskApiService taskApiService)
        {
            _logger = logger;
            _config = config;
			_mapper = mapper;
			_apiMenuService = menuApiService;
			_apiTaskService = taskApiService;
        }

		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			MenuControllerRequest request = new MenuControllerRequest();
			string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
			request.ControllerName = controllerName;

			var apiResponse = await _apiMenuService.GetMenuController(request, cancellationToken);
			ViewBag.DataMenu = apiResponse.Data;
			ViewBag.Title = "Dashboard";

            return View();
        }

        [HttpPost]
        public async Task<IEnumerable<TaskTotalByProjectResponse>> SearchProject([FromBody] FindProjectInputModel model, CancellationToken cancellationToken)
        {
            var apiRequest = _mapper.Map<FindProjectRequest>(model);
            var apiResponse = await _apiTaskService.SearchGetTotalTask(apiRequest, cancellationToken);

            if (apiResponse.Error)
            {
                var data = apiResponse.Data;
                return data;
            }
            var result = apiResponse.Data;
            return result;
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