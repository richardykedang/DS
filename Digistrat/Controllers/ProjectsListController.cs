using AutoMapper;
using Digistrat.Models.Project;
using Digistrat.Services.Interfaces;
using Digistrat.Shared.Dtos.Requests.Project;
using Digistrat.Shared.Dtos.Responses;
using Digistrat.Shared.Dtos.Responses.MsProject;
using Microsoft.AspNetCore.Mvc;

namespace Digistrat.Controllers
{
	public class ProjectsListController : Controller
	{
		private readonly ILogger<ProjectsListController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IProjectApiService _apiProjectService;

        public ProjectsListController(ILogger<ProjectsListController> logger, IConfiguration config, IMapper mapper, IProjectApiService projectApiService)
		{
			_logger = logger;
			_mapper = mapper;
			_config = config;
			_apiProjectService = projectApiService;
		}

		public IActionResult Index()
		{
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
    }
}
