using AutoMapper;
using Digiproj.Shared.Dtos.Requests;
using Digiproj.Shared.Dtos.Responses;
using DigiProj.Helpers;
using DigiProj.Models.Project;
using DigiProj.Services.Interfaces;
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


		#region CRUD
		[Route("/projects-new")]
		public IActionResult Create()
		{
			ViewBag.Title = "Add Project";
			return View();
		}

		[Route("/projects-edit")]
		public IActionResult Edit()
		{
			ViewBag.Title = "Edit Project";
			return View();
		}

		[HttpPost]
		public async Task<DeleteResponse> Delete([FromBody] DeleteProjectInputModel model, CancellationToken cancellationToken)
		{

			DeleteResponse msg = new DeleteResponse();
			var apiRequest = _mapper.Map<DeleteProjectRequest>(model);
			var apiResponse = await _apiProjectService.DeleteProject(apiRequest, cancellationToken);

			if (apiResponse.Error)
			{
				msg.success = false;
				msg.message = apiResponse.Message;
				return msg;
			}

			msg.success = true;
			msg.message = apiResponse.Message;
			return msg;

		}

		[HttpGet()]
		[Route("/project/projects-detail")]
		public async Task<IActionResult> Detail([FromQuery] string ProjectId, CancellationToken cancellationToken)
		{
			ViewBag.Title = "Detail Project";
			ViewBag.ID = Encryption.Decrypt(ProjectId);
			var m = await _apiProjectService.GetDetailProject(Encryption.Decrypt(ProjectId), cancellationToken);

			ProjectResponse model = new();
			model = new()
			{
				ProjectName = m.Data.First().ProjectName,
				Status = m.Data.First().Status,
				ProjectOwner = m.Data.First().ProjectOwner,
				Summary = m.Data.First().Summary,
				CreatedBy = m.Data.First().CreatedBy,
				CreatedDate = m.Data.First().CreatedDate,
				EndDate = m.Data.First().EndDate,
			};

			return View(model);
		}
		#endregion
	}
}
