﻿using AutoMapper;
using Digistrat.Helpers;
using Digistrat.Models.Account;
using Digistrat.Services.Interfaces;
using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Digistrat.Controllers
{
	public class ProfileController : Controller
	{
		private readonly ILogger<ProfileController> _logger;
		private readonly IConfiguration _config;
		private readonly IMapper _mapper;
		private readonly IUserApiService _apiService;

		public ProfileController(ILogger<ProfileController> logger, IConfiguration config, IMapper mapper, IUserApiService apiService)
		{
			_logger = logger;
			_config = config;
			_mapper = mapper;
			_apiService = apiService;
		}


		[Route("/profile")]
		public IActionResult Index()
		{
			ViewBag.Title = "My Profile";
			return View();
		}

		public IActionResult ChangePassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<ChangePasswordResponse> ChangePassword([FromBody] ChangePasswordInputModel model, CancellationToken cancellationToken)
		{

			ChangePasswordResponse msg = new ChangePasswordResponse();
			var apiRequest = _mapper.Map<ChangePasswordRequest>(model);
			var apiResponse = await _apiService.ChangePasswordAsync(apiRequest, cancellationToken);

			if (apiResponse.Error)
			{
				msg.success = false;
				msg.message = apiResponse.Message;
				return msg;
			}
			HttpContext.DeleteCookies();

			msg.success = true;
			msg.message = apiResponse.Message;
			return msg;

		}
	}
}