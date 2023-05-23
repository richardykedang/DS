using AutoMapper;
using DigiProj.Configuration;
using DigiProj.Helpers;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsUser;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests;
using Newtonsoft.Json;
using RestSharp;
using DigiProj.Shared.Dtos.Responses.MsProject;
using Digiproj.Shared.Dtos.Requests.Users;
using System.Diagnostics;
using System.Net;
using System;

namespace DigiProj.Services
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

		public async Task<GlobalResponse> ChangePasswordAsync(ChangePasswordRequest requestDto, CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriChangePassword, Method.POST);


			requestDto.Password = requestDto.Password;
			requestDto.OldPassword = requestDto.OldPassword;

			request.AddRequiredBody(requestDto);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalResponse>();
		}


		public async Task<GlobalObjectResponse<ProfilUserResponse>> GetProfilUserAsync(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriGetProfileUser, Method.GET);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			//string jsonString = "{\"code\":200,\"error\":false,\"message\":\"Successfully get user roles.\",\"data\":[{\"name\":\"admin\",\"email\":\"alvin.joe49@bi.go.id\",\"nip\":\"12345\",\"username\":\"alvin\",\"path_signature\":null,\"is_active\":true,\"user_roles\":\"Administrator,\"}]}";
			//var jsonV = JsonConvert.DeserializeObject<GlobalObjectResponse<ProfilUserResponse>>(response.Content);
			//Console.WriteLine(jsonV);
			return response.GetContent<GlobalObjectResponse<ProfilUserResponse>>();
		}


        public async Task<GlobalObjectListResponse<UserRolesResponse>> GetRolesAsync(CancellationToken cancellationToken)
        {
            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriGetUserRoles, Method.GET);
            request.AddRequiredHeaders(_apiConfig);

            var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

            return response.GetContent<GlobalObjectListResponse<UserRolesResponse>>();
        }

        public async Task<GlobalObjectListResponse<UserMenusResponse>> GetMenusAsync(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriGetUserMenus, Method.GET);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalObjectListResponse<UserMenusResponse>>();
		}

		public async Task<GlobalObjectListResponse<UserResponse>> GetUsers(CancellationToken cancellationToken)
		{
			var token = await _tokenService.CheckTokenAsync(cancellationToken);
			_client.AddAuthenticator(token);

			var request = new RestRequest(_apiConfig.UriGetUser, Method.GET);
			request.AddRequiredHeaders(_apiConfig);

			var response = await _client.ExecuteAsync(request, cancellationToken);
			response.CheckError(request);

			return response.GetContent<GlobalObjectListResponse<UserResponse>>();
		}

	}
}
