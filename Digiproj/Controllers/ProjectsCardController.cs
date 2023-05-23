using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests.Project;
using System.Reflection;
using DigiProj.Models.Project;
using DigiProj.Helpers;

namespace DigiProj.Controllers
{
	public class ProjectsCardController : Controller
	{
		private readonly ILogger<ProjectsCardController> _logger;
		private readonly IMapper _mapper;
		private readonly IConfiguration _config;
		private readonly IProjectApiService _apiProjectService;

		public ProjectsCardController(ILogger<ProjectsCardController> logger, IConfiguration config, IMapper mapper, IProjectApiService projectApiService)
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
	}
}
