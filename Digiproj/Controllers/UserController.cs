using AutoMapper;
using DigiProj.Helpers;
using DigiProj.Models.Project;
using DigiProj.Services.Interfaces;
using Digiproj.Shared.Dtos.Requests;
using Microsoft.AspNetCore.Mvc;
using DigiProj.Shared.Dtos.Responses.MsUser;
using Digiproj.Shared.Dtos.Requests.Users;
using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Models.Users;

namespace DigiProj.Controllers
{
	public class UserController : Controller
	{
		private readonly ILogger<UserController> _logger;
		private readonly IMapper _mapper;
		private readonly IConfiguration _config;
		private readonly IMenuApiService _apiMenuService;
		private readonly IUserApiService _apiUserService;

		public UserController(ILogger<UserController> logger, IConfiguration config, IMapper mapper, IMenuApiService menuApiService, IUserApiService apiUserService)
		{
			_logger = logger;
			_mapper = mapper;
			_config = config;
			_apiMenuService = menuApiService;
			_apiUserService = apiUserService;
		}

		[Route("/user")]
		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			MenuControllerRequest request = new MenuControllerRequest();
			string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
			request.ControllerName = controllerName;

			var apiResponse = await _apiMenuService.GetMenuController(request, cancellationToken);
			ViewBag.DataMenu = apiResponse.Data;

			ViewBag.Title = "User Management";
			return View();
		}

        public async Task<IEnumerable<UserResponse>> SearchUser([FromBody] SearchUserInputModel model, CancellationToken cancellationToken)
        {

            var apiRequest = _mapper.Map<UserRequest>(model);
            var apiResponse = await _apiUserService.GetSearchUser(apiRequest, cancellationToken);

            if (apiResponse.Error)
            {
                var datauser = apiResponse.Data;
                return datauser;
            }
            var users = apiResponse.Data;

            return users;

        }
    }
}
