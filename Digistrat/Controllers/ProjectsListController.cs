using Microsoft.AspNetCore.Mvc;

namespace Digistrat.Controllers
{
	public class ProjectsListController : Controller
	{
		private readonly ILogger<ProjectsListController> _logger;

		public ProjectsListController(ILogger<ProjectsListController> logger)
		{
			_logger = logger;
		}

		[Route("/projects-list")]
		public IActionResult Index()
		{
			ViewBag.Title = "List Project";
			return View();
		}
	}
}
