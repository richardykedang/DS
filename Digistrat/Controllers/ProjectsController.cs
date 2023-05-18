using Digistrat.Shared.Dtos.Responses.MsProject;
using Digistrat.Shared.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Digistrat.Services.Interfaces;
using Digistrat.Shared.Dtos.Requests.Project;
using System.Reflection;
using Digistrat.Models.Project;
using Digistrat.Helpers;

namespace Digistrat.Controllers
{
	public class ProjectsController : Controller
	{
		private readonly ILogger<ProjectsController> _logger;
		private readonly IMapper _mapper;
		private readonly IConfiguration _config;
		private readonly IProjectApiService _apiProjectService;

		public ProjectsController(ILogger<ProjectsController> logger, IConfiguration config, IMapper mapper, IProjectApiService projectApiService)
		{
			_logger = logger;
			_mapper = mapper;
			_config = config;
			_apiProjectService = projectApiService;
		}

		[Route("/projects")]
		public IActionResult Index()
		{
			ViewBag.Title = "Project";
			return View();
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
				Name= m.Data.First().Name,
                Approval = m.Data.First().Approval,
                Summary = m.Data.First().Summary,
				CreatedBy = m.Data.First().CreatedBy,
				CreatedDate= m.Data.First().CreatedDate,
				EndDate= m.Data.First().EndDate,
			};

			return View(model);
		}

		[Route("/projects-edit")]
		public IActionResult Edit()
		{
			ViewBag.Title = "Edit Project";
			return View();
		}
	}
}
