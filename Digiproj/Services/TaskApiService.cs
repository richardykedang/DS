using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using RestSharp;
using DigiProj.Configuration;
using DigiProj.Shared.Dtos.Responses.MsTask;
using DigiProj.Helpers;
using Digiproj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Requests.Project;
using Digiproj.Shared.Dtos.Requests.Task;

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

        public async Task<GlobalResponse> CreateTask(CreateTaskRequest requestDto, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);


            var request = new RestRequest(_apiConfig.UriCreateTask, Method.POST);

            requestDto.ProjectId = requestDto.ProjectId;
            requestDto.TaskName = requestDto.TaskName;
            requestDto.TaskOwner = requestDto.TaskOwner;
            requestDto.Priority = requestDto.Priority;
            requestDto.StartDate = requestDto.StartDate;
            requestDto.EndDate = requestDto.EndDate;


            request.AddRequiredBody(requestDto);
            request.AddRequiredHeaders(_apiConfig);

            var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

            return response.GetContent<GlobalResponse>();
        }

        public async Task<GlobalResponse> DeleteTask(DeleteTaskRequest requestDto, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriDeleteTask, Method.POST);
            request.AddRequiredBody(requestDto);
            request.AddRequiredHeaders(_apiConfig);

            var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

            return response.GetContent<GlobalResponse>();
        }

        public async Task<GlobalResponse> UpdateTask(UpdateTaskRequest requestDto, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriEditTask, Method.POST);
            request.AddRequiredBody(requestDto);
            request.AddRequiredHeaders(_apiConfig);

            var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

            return response.GetContent<GlobalResponse>();
        }

		public async Task<GlobalObjectListResponse<TaskTotalByProjectResponse>> GetTotalTaskByProject(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriGetTotalTaskByProject, Method.GET);
			request.AddRequiredHeaders(_apiConfig);
			var response = await _client.ExecuteGetAsync(request, cancellationToken);
			response.CheckError(request);
			return response.GetContent<GlobalObjectListResponse<TaskTotalByProjectResponse>>();
		}

		public async Task<GlobalObjectListResponse<TotalDashboardResponse>> GetTotalTask(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriGetTotalTask, Method.GET);
			request.AddRequiredHeaders(_apiConfig);
			var response = await _client.ExecuteGetAsync(request, cancellationToken);
			response.CheckError(request);
			return response.GetContent<GlobalObjectListResponse<TotalDashboardResponse>>();
		}

	}
}
