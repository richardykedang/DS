using Microsoft.AspNetCore.Mvc;

namespace Digistrat.Controllers
{
	public class ProjectsController : Controller
	{
		private readonly ILogger<ProjectsController> _logger;

		public ProjectsController(ILogger<ProjectsController> logger)
		{
			_logger = logger;
		}

		[Route("/projects")]
		public IActionResult Index()
		{
			ViewBag.Title = "Project";
			return View();
		}

		[Route("/projects-details")]
		public IActionResult Detail()
		{
			ViewBag.Title = "Detail Project";
			return View();
		}

		[Route("/projects-edit")]
		public IActionResult Edit()
		{
			ViewBag.Title = "Edit Project";
			return View();
		}
	}
}
