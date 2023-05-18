using Microsoft.AspNetCore.Mvc;

namespace Digistrat.Controllers
{
	public class TaskListController : Controller
	{
		private readonly ILogger<TaskListController> _logger;
		public TaskListController(ILogger<TaskListController> logger)
		{
			_logger = logger;
		}

		[Route("/tasks-list")]
		public IActionResult Index()
		{
			ViewBag.Title = "Task List";
			return View();
		}
		[Route("/tasks-create")]
		public IActionResult Add()
		{
			ViewBag.Title = "Add Task";
			return View();
		}

		[Route("/tasks-edit")]
		public IActionResult Edit()
		{
			ViewBag.Title = "Edit Task";
			return View();
		}
	}
}
