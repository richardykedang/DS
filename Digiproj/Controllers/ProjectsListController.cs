using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Digiproj.Shared.Dtos.Requests;
using Digiproj.Shared.Dtos.Responses;
using DigiProj.Helpers;
using DigiProj.Models.Project;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses.MsTask;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DigiProj.Controllers
{
    public class ProjectsListController : Controller
	{
		private readonly ILogger<ProjectsListController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IProjectApiService _apiProjectService;
        private readonly ITaskApiService _apiTaskService;
        private readonly IMenuApiService _apiMenuService;
		private readonly IUserApiService _apiUserService;
		private readonly INotyfService _notyfService;


		public ProjectsListController(ILogger<ProjectsListController> logger, IConfiguration config, IMapper mapper , INotyfService notyfService,IProjectApiService projectApiService, ITaskApiService taskApiService , IMenuApiService menuApiService, IUserApiService userApiService)
		{
			_logger = logger;
			_mapper = mapper;
			_config = config;
			_apiProjectService = projectApiService;
			_apiTaskService = taskApiService;
            _apiMenuService = menuApiService;
			_apiUserService = userApiService;
			_notyfService= notyfService;
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
		public async Task<GlobalObjectListResponse<TextModelResponse>> GetAutoCompleteStatus(CancellationToken cancellationToken)
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

        [HttpGet]
        [Route("/project/projects-edit")]
		public async Task<IActionResult> Edit([FromQuery] string ProjectId, CancellationToken cancellationToken)
		{
			ViewBag.Title = "Edit Project";
            ViewBag.ID = Encryption.Decrypt(ProjectId);
            return View();
		}
        
		[HttpGet]
        [Route("/project/projects-detail")]
        public async Task<IActionResult> Detail([FromQuery] string ProjectId, CancellationToken cancellationToken)
        {
            ViewBag.Title = "Detail Project";
            ViewBag.ID = Encryption.Decrypt(ProjectId);
            return View();
        }

        [HttpPost]
		public async Task<GlblMsg> Create([FromBody] CreateProjectInputModel model, CancellationToken cancellationToken)
		{
			GlblMsg msg = new GlblMsg();
			var apiRequest = _mapper.Map<CreateProjectRequest>(model);
			var apiResponse = await _apiProjectService.CreateProject(apiRequest, cancellationToken);

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

		[HttpPost]
		public async Task<GlblMsg> Update([FromBody] UpdateProjectInputModel model, CancellationToken cancellationToken)
		{
			GlblMsg msg = new GlblMsg();
			var apiRequest = _mapper.Map<UpdateProjectRequest>(model);
			var apiResponse = await _apiProjectService.UpdateProject(apiRequest, cancellationToken);

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

		[HttpPost]
		public async Task<GlblMsg> Delete([FromBody] DeleteProjectInputModel model, CancellationToken cancellationToken)
		{

			GlblMsg msg = new GlblMsg();
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

        [HttpGet]
        public async Task<IEnumerable<TaskProjectesponse>> GetTaskByEmployee([FromQuery] string EmployeeId,string ProjectId, CancellationToken cancellationToken)
		{
            var apiResponse = await _apiTaskService.GetTaskEmployeeProject(EmployeeId, ProjectId, cancellationToken);

            if (apiResponse.Error)
            {
                var dataTaskEmployee = apiResponse.Data;
                return dataTaskEmployee;
            }
            var resultTaskEmployee = apiResponse.Data;
            return resultTaskEmployee;
        }
        #endregion
    }
}
