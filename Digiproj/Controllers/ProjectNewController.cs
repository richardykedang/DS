using Microsoft.AspNetCore.Mvc;

namespace Digistrat.Controllers
{
	public class ProjectNewController : Controller
	{
		private readonly ILogger<ProjectNewController> _logger;

		public ProjectNewController(ILogger<ProjectNewController> logger)
		{
			_logger = logger;
		}

		[Route("/projects-new")]
		public IActionResult Index()
		{
			ViewBag.Title = "Add Project";
			return View();
		}
	}
}
