using DigiProj.Configuration;
using DigiProj.Helpers;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsProject;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DigiProj.Services
{
    public class ProjectApiService : IProjectApiService
    {
        private readonly ITokenService _tokenService;

        private readonly RestClient _client;
        private readonly ApiConfiguration _apiConfig;

        public ProjectApiService(IConfiguration configuration, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
            _client = new RestClient(_apiConfig.BaseUrl);
        }

        public async Task<GlobalObjectListResponse<ProjectResponse>> GetProjects(CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriGetProject, Method.GET);
            request.AddRequiredHeaders(_apiConfig);

            var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

            return response.GetContent<GlobalObjectListResponse<ProjectResponse>>();

        }
        public async Task<GlobalObjectListResponse<ProjectResponse>> GetSearchProject(SearchProjectRequest requestDto, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriSearchProject, Method.POST);
            requestDto.PageSize = 1000;
			requestDto.PageIndex = 1;
			
            var sort = new Sort();
			sort.Field = requestDto.Column;
			sort.IsAscending = requestDto.Y ? false:true;
            requestDto.Sort.Add(sort);


			request.AddRequiredBody(requestDto);
            request.AddRequiredHeaders(_apiConfig);
            

            var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

            return response.GetContent<GlobalObjectListResponse<ProjectResponse>>();
        }
		public async Task<GlobalObjectListResponse<ModelResponse>> GetAutoCompleteStatus(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var requestDto = new FilterAutoComplete();
			var request = new RestRequest(_apiConfig.UriAutoCompleteStatus, Method.POST);
			requestDto.limit = 5;
			requestDto.q = "";


			request.AddRequiredBody(requestDto);
			request.AddRequiredHeaders(_apiConfig);


			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalObjectListResponse<ModelResponse>>();
		}

		public async Task<GlobalResponse> DeleteProject(DeleteProjectRequest requestDto, CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriDeleteProject, Method.POST);
			request.AddRequiredBody(requestDto);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalResponse>();
		}


		public async Task <GlobalObjectListResponse<ProjectResponse>> GetDetailProject(string ProjectId, CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriDetailProject, Method.GET);
			request.AddParameter("ProjectId", ProjectId, ParameterType.QueryString);
		    request.AddRequiredHeaders(_apiConfig);
            var response = await _client.ExecuteGetAsync(request, cancellationToken);
            response.CheckError(request);
			//var jsonV = JsonConvert.DeserializeObject<GlobalObjectListResponse<ProjectResponse>>(response.Content);
			//return jsonV;
			return response.GetContent<GlobalObjectListResponse<ProjectResponse>>();
		}

	}
}
