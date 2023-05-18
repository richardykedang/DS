using DigiProj.Configuration;
using DigiProj.Helpers;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Responses;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace DigiProj.Services
{
	public class AuthenticationApiService : IAuthenticationApiService
	{
		private readonly RestClient _client;
		private readonly ApiConfiguration _apiConfig;

		public AuthenticationApiService(IConfiguration configuration)
		{
			_apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
			_client = new RestClient(_apiConfig.BaseUrl);
		}

		public async Task<TokenResponse> LoginAsync(LoginRequest requestDto, CancellationToken cancellationToken)
		{
			var request = new RestRequest(_apiConfig.UriLogin, Method.POST);
			requestDto.Username = requestDto.Username;
			requestDto.Password = requestDto.Password;//SecurityHelper.GetPasswordEncrypted(requestDto.Password);

			request.AddRequiredBody(requestDto);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			//response.CheckError(request);

			return response.GetContent<TokenResponse>();
		}

		public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest requestDto, CancellationToken cancellationToken)
		{
			var request = new RestRequest(_apiConfig.UriRefreshToken, Method.POST);

			request.AddRequiredBody(requestDto);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<TokenResponse>();
		}

		public async Task<GlobalObjectResponse<MaintenanceResponse>> GetMaintenanceAsync(CancellationToken cancellationToken)
		{
			var request = new RestRequest(_apiConfig.UriGetMaintenance, Method.GET);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);

			return response.GetContent<GlobalObjectResponse<MaintenanceResponse>>();
		}
	}
}
