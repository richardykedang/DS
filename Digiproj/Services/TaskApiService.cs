using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using RestSharp;
using DigiProj.Configuration;
using DigiProj.Shared.Dtos.Responses.MsTask;
using DigiProj.Helpers;

namespace DigiProj.Services
{
    public class TaskApiService: ITaskApiService
    {
        private readonly ITokenService _tokenService;
        private readonly RestClient _client;
        private readonly ApiConfiguration _apiConfig;

        public TaskApiService(IConfiguration configuration, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
            _client = new RestClient(_apiConfig.BaseUrl);
        }


        public async Task<GlobalObjectListResponse<TaskTotalResponse>> GetTotalTaskProject(string ProjectId, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriTaskProjectTotal, Method.GET);
            request.AddParameter("ProjectId", ProjectId, ParameterType.QueryString);
            request.AddRequiredHeaders(_apiConfig);
            var response = await _client.ExecuteGetAsync(request, cancellationToken);
            response.CheckError(request);
            return response.GetContent<GlobalObjectListResponse<TaskTotalResponse>>();
        }

        public async Task<GlobalObjectListResponse<TaskDetailResponse>> GetMemberProjectDetailAsync(string ProjectId, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriGetMemberTaskProject, Method.GET);
            request.AddParameter("ProjectId", ProjectId, ParameterType.QueryString);
            request.AddRequiredHeaders(_apiConfig);
            var response = await _client.ExecuteGetAsync(request, cancellationToken);
            response.CheckError(request);
            return response.GetContent<GlobalObjectListResponse<TaskDetailResponse>>();
        }

        public async Task<GlobalObjectListResponse<TaskProjectesponse>> GetTaskProject(string ProjectId, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriGetTaskProject, Method.GET);
            request.AddParameter("ProjectId", ProjectId, ParameterType.QueryString);
            request.AddRequiredHeaders(_apiConfig);
            var response = await _client.ExecuteGetAsync(request, cancellationToken);
            response.CheckError(request);
            return response.GetContent<GlobalObjectListResponse<TaskProjectesponse>>();
        }

        public async Task<GlobalObjectListResponse<TaskProjectesponse>> GetTaskEmployeeProject(string EmployeeId, string ProjectId, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriGetTaskEmployeeProject, Method.GET);
            request.AddParameter("EmployeeId", EmployeeId, ParameterType.QueryString);
            request.AddParameter("ProjectId", ProjectId, ParameterType.QueryString);
            request.AddRequiredHeaders(_apiConfig);
            var response = await _client.ExecuteGetAsync(request, cancellationToken);
            response.CheckError(request);
            return response.GetContent<GlobalObjectListResponse<TaskProjectesponse>>();
        }
    }
}
