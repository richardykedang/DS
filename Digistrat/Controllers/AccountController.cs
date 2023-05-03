using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Digistrat.Helpers;
using Digistrat.Services.Interfaces;
using Digistrat.Shared.Dtos.Requests;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Digistrat.Models.Account;
using Digistrat.Shared.Configuration.Constants;

namespace Digistrat.Controllers
{
	public class AccountController : Controller
	{
		private readonly ITokenService _tokenService;
		private readonly IUserApiService _apiService;
		private readonly IMapper _mapper;
		private readonly INotyfService _notifyService;

		public AccountController(ITokenService tokenService, IUserApiService apiService, IMapper mapper, INotyfService notifyService)
		{
			_tokenService = tokenService;
			_apiService = apiService;
			_mapper = mapper;
			_notifyService = notifyService;
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction(nameof(HomeController.Index), "Home");


            return View();
        }

		[AllowAnonymous]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginInputModel model, CancellationToken cancellationToken)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var apiRequest = _mapper.Map<LoginRequest>(model);

			var apiResponse = await _tokenService.GenerateTokenAsync(apiRequest, cancellationToken);

            
            if (apiResponse.Error)
			{
				_notifyService.Error(apiResponse.Message);
				return View(model);
			}

			var jwtToken = _tokenService.GetToken();

			//Get user roles from api
			//var apiResponseRoles = await _apiService.GetRolesAsync(cancellationToken);
			//var roles = _mapper.Map<IEnumerable<UserRolesResponse>>(apiResponseRoles.Data);
			//if (!roles.Any())
			//{
			//	_notifyService.Error("User tidak terdaftar pada role apapun");
			//	return View(model);
			//}

			/*COOKIE AUTH*/
			var claims = jwtToken.Claims.ToList();

			//Additional claims for web 
			claims.Add(new Claim(ClaimTypes.Name, claims.Find(claim => claim.Type == JwtClaimTypeConsts.PreferredUserName)?.Value));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, claims.Find(claim => claim.Type == JwtClaimTypeConsts.Name)?.Value));
			
			//Roles
			//foreach (var role in roles)
			//	claims.Add(new Claim(ClaimTypes.Role, role.RoleName));


			var claimsIdentity = new ClaimsIdentity(
				claims, CookieAuthenticationDefaults.AuthenticationScheme);

			var authProperties = new AuthenticationProperties
			{
				AllowRefresh = true,
				ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(apiResponse.ExpiresIn),
				IsPersistent = false,
			};

			await HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity),
				authProperties);

			////Get system control from api
			//var apiResponseSysControl = await _apiService.GetSystemControlAsync(cancellationToken);
			//var sysControl = _mapper.Map<SystemControl>(apiResponseSysControl.Data);
			//sysControl.AddSystemControl();

			//if (Url.IsLocalUrl(model.ReturnUrl))
			//    return Redirect(model.ReturnUrl);

			return RedirectToAction("Index", "Profile");

		}

		//[HttpGet]
		//public IActionResult ChangePassword()
		//{
		//	ModelState.AddModelError(string.Empty, "Anda diwajibkan untuk mengganti password ketika baru pertama kali login atau tidak ganti password selama minimal 3 bulan.");
		//	return View();
		//}


		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutCookieAsync();

			return RedirectToAction(nameof(AccountController.Logout), "Account");

		}
	}
}
