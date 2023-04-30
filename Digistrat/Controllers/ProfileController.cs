using Microsoft.AspNetCore.Mvc;

namespace Digistrat.Controllers
{
	public class ProfileController : Controller
	{
		private readonly ILogger<ProfileController> _logger;
		private readonly IConfiguration _config;

		public ProfileController(ILogger<ProfileController> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
		}


		[Route("/profile")]
		public IActionResult Index()
		{
			ViewBag.Title = "My Profile";
			return View();
		}
	}
}
