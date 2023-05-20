using AutoMapper;
using Digiproj.Shared.Dtos.Requests;
using DigiProj.Models;
using DigiProj.Models.Project;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsProject;
using Microsoft.AspNetCore.Mvc;

namespace DigiProj.Controllers
{
    public class ProjectsListController : Controller
	{
		private readonly ILogger<ProjectsListController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IProjectApiService _apiProjectService;
        private readonly IMenuApiService _apiMenuService;

        public ProjectsListController(ILogger<ProjectsListController> logger, IConfiguration config, IMapper mapper, IProjectApiService projectApiService, IMenuApiService menuApiService)
		{
			_logger = logger;
			_mapper = mapper;
			_config = config;
			_apiProjectService = projectApiService;
            _apiMenuService = menuApiService;
		}

		[Route("/project")]
		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
            MenuControllerRequest request = new MenuControllerRequest();
            string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            request.ControllerName = controllerName;

            var apiResponse = await _apiMenuService.GetMenuController(request, cancellationToken);
            ViewBag.DataMenu = apiResponse.Data;

            ViewBag.Title = "List Project";
			return View();
		}

        [HttpGet]
        public async Task<GlobalObjectListResponse<ProjectResponse>> ListProject(CancellationToken cancellationToken)
        {
            var apiResponse = await _apiProjectService.GetProjects(cancellationToken);
            return apiResponse;
        }

        [HttpPost]
        public async Task<IEnumerable<ProjectResponse>> SearchProject([FromBody] SearchProjectInputModel model, CancellationToken cancellationToken)
        {

            var apiRequest = _mapper.Map<SearchProjectRequest>(model);
            var apiResponse = await _apiProjectService.GetSearchProject(apiRequest, cancellationToken);

            if (apiResponse.Error)
            {
                var dataDepartment = apiResponse.Data;
                return dataDepartment;
            }
            var resultDepartment = apiResponse.Data;
            return resultDepartment;

        }


		[HttpPost]
		public async Task<GlobalObjectListResponse<ModelResponse>> GetAutoCompleteStatus(CancellationToken cancellationToken)
		{
			var apiResponse = await _apiProjectService.GetAutoCompleteStatus(cancellationToken);
			return apiResponse;

		}

	}
}
