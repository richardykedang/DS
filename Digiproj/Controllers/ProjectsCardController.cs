using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests.Project;
using System.Reflection;
using DigiProj.Models.Project;
using DigiProj.Helpers;
using AspNetCoreHero.ToastNotification.Notyf;
using DigiProj.Services;
using AspNetCoreHero.ToastNotification.Abstractions;
using Digiproj.Shared.Dtos.Requests;

namespace DigiProj.Controllers
{
	public class ProjectsCardController : Controller
	{
		private readonly ILogger<ProjectsCardController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IProjectApiService _apiProjectService;
        private readonly ITaskApiService _apiTaskService;
        private readonly IMenuApiService _apiMenuService;
        private readonly IUserApiService _apiUserService;
        private readonly INotyfService _notyfService;

        public ProjectsCardController(ILogger<ProjectsCardController> logger, IConfiguration config, IMapper mapper, INotyfService notyfService, IProjectApiService projectApiService, ITaskApiService taskApiService, IMenuApiService menuApiService, IUserApiService userApiService)
        {
            _logger = logger;
			_mapper = mapper;
			_config = config;
            _apiProjectService = projectApiService;
            _apiTaskService = taskApiService;
            _apiMenuService = menuApiService;
            _apiUserService = userApiService;
            _notyfService = notyfService;
        }

		[Route("/projects-card")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            MenuControllerRequest request = new MenuControllerRequest();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            request.ControllerName = controllerName;

            var apiResponse = await _apiMenuService.GetMenuController(request, cancellationToken);
            ViewBag.DataMenu = apiResponse.Data;
            ViewBag.Title = "Project-Card";
			return View();
		}
	}
}
