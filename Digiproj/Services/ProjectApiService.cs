using Digiproj.Shared.Dtos.Requests.Project;
using DigiProj.Configuration;
using DigiProj.Configuration.Constants;
using DigiProj.Helpers;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsProject;
using HtmlAgilityPack;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Threading.Tasks;

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
		public async Task<GlobalObjectListResponse<TextModelResponse>> GetAutoCompleteStatus(CancellationToken cancellationToken)
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

			return response.GetContent<GlobalObjectListResponse<TextModelResponse>>();
		}


		public async Task<GlobalResponse> CreateProject(CreateProjectRequest requestDto, CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);


			var request = new RestRequest(_apiConfig.UriCreateProject, Method.POST);
			
			requestDto.ProjectId = requestDto.ProjectId;
			requestDto.ProjectName = requestDto.ProjectName;
			requestDto.ProjectOwner = requestDto.ProjectOwner;
			requestDto.DepartmentId = requestDto.DepartmentId;
			requestDto.Status = 1;
			requestDto.Summary = requestDto.Summary;
			requestDto.StartDate = requestDto.StartDate;
			requestDto.EndDate = requestDto.EndDate;
			requestDto.IsActive = true;


			////saving Array Member
			foreach (var b in requestDto.EmployeeId)
			{
				var sort = new AssignToRequest()
				{
					ProjectId = requestDto.ProjectId,
					EmployeeId = b
				};

				requestDto.AssignTo.Add(sort);
			}

			request.AddRequiredBody(requestDto);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalResponse>();
		}

		public async Task<GlobalResponse> UpdateProject(UpdateProjectRequest requestDto, CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);


			var request = new RestRequest(_apiConfig.UriUpdateProject, Method.POST);

			requestDto.ProjectId = requestDto.ProjectId;
			requestDto.ProjectName = requestDto.ProjectName;
			requestDto.ProjectOwner = requestDto.ProjectOwner;
			requestDto.DepartmentId = requestDto.DepartmentId;
			requestDto.Status = requestDto.Status;
			requestDto.Summary = requestDto.Summary;
			requestDto.StartDate = requestDto.StartDate;
			requestDto.EndDate = requestDto.EndDate;
			requestDto.IsActive = requestDto.IsActive;

			request.AddRequiredBody(requestDto);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalResponse>();
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

		//public async Task<string> GetProjectLastNumber(CancellationToken cancellationToken)
		//{
		//	var token = await _tokenService.CheckTokenAsync(cancellationToken);
		//	_client.AddAuthenticator(token);

		//	var request = new RestRequest(_apiConfig.UriGetProjectLastNumber, Method.GET);
		//	request.AddRequiredHeaders(_apiConfig);
		//	var response = await _client.ExecuteAsync(request, cancellationToken);
		//	response.CheckError(request);

		//	return response.GetContent<string>();
		//}
	}
}
