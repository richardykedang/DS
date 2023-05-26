using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using RestSharp;
using DigiProj.Configuration;
using Digiproj.Shared.Dtos.Responses.MsDepartment;
using DigiProj.Helpers;

namespace DigiProj.Services
{
	public class DepartmentApiService : IDepartmentService
	{
		private readonly ITokenService _tokenService;

		private readonly RestClient _client;
		private readonly ApiConfiguration _apiConfig;

		public DepartmentApiService(IConfiguration configuration, ITokenService tokenService)
		{
			_tokenService = tokenService;
			_apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
			_client = new RestClient(_apiConfig.BaseUrl);
		}

		public async Task<GlobalObjectListResponse<DepartmentResponse>> GetDepartment(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriGetDepartment, Method.GET);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalObjectListResponse<DepartmentResponse>>();

		}
	}
}
