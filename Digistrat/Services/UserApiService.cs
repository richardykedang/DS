using AspNetCoreHero.ToastNotification.Helpers;
using AutoMapper;
using Digistrat.Configuration;
using Digistrat.Helpers;
using Digistrat.Services.Interfaces;
using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Responses;
using Digistrat.Shared.Dtos.Responses.MsUser;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Security.Claims;

namespace Digistrat.Services
{
    public class UserApiService : IUserApiService
	{
		private readonly ITokenService _tokenService;

		private readonly RestClient _client;
        private readonly IMapper _mapper;
        private readonly ApiConfiguration _apiConfig;

		public UserApiService(IMapper mapper, IConfiguration configuration, ITokenService tokenService)
		{	
			_mapper = mapper;
			_tokenService = tokenService;
			_apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
			_client = new RestClient(_apiConfig.BaseUrl);
		}

		//public async Task<GlobalResponse> ChangePasswordAsync(ChangePasswordRequest requestDto, CancellationToken cancellationToken)
		//{
		//	var token = await _tokenService.CheckTokenAsync(cancellationToken);
		//	_client.AddAuthenticator(token);

		//	var request = new RestRequest(_apiConfig.UriChangePassword, Method.POST);


		//	if (System.Text.RegularExpressions.Regex.IsMatch(requestDto.Password, "(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[~!@#$%^&*()_+={}\\[\\]:\"\"|\\;,./<>?'']).{8,}$"))
		//	{
		//		requestDto.Password = SecurityHelper.GetPasswordEncrypted(requestDto.Password);
		//		requestDto.ConfirmPassword = SecurityHelper.GetPasswordEncrypted(requestDto.ConfirmPassword);
		//	}



		//	request.AddRequiredBody(requestDto);
		//	request.AddRequiredHeaders(_apiConfig);

		//	var response = await _client.ExecuteAsync(request, cancellationToken);
		//	response.CheckError(request);

		//	return response.GetContent<GlobalResponse>();
		//}

		//public async Task<GlobalObjectResponse<SystemControlResponse>> GetSystemControlAsync(CancellationToken cancellationToken)
		//{
		//    var token = await _tokenService.CheckTokenAsync(cancellationToken);
		//    _client.AddAuthenticator(token);

		//    var request = new RestRequest(_apiConfig.UriGetSystemControl, Method.GET);
		//    request.AddRequiredHeaders(_apiConfig);

		//    var response = await _client.ExecuteAsync(request, cancellationToken);
		//    response.CheckError(request);

		//    return response.GetContent<GlobalObjectResponse<SystemControlResponse>>();
		//}


		public async Task<GlobalObjectResponse<ProfilUserResponse>> GetProfilUserAsync(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriGetProfileUser, Method.GET);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

			var jsonV = JsonConvert.DeserializeObject<GlobalObjectResponse<ProfilUserResponse>>(response.Content);
			return jsonV;
			//Console.WriteLine(jsonV);
			//return response.GetContentTest<GlobalObjectListResponse<ProfilUserResponse>>();
		}





	}
}
