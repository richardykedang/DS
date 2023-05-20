using DigiProj.Configuration;
using DigiProj.Services.Interfaces;
using Digiproj.Shared.Dtos.Responses.MsMenu;
using DigiProj.Shared.Dtos.Responses;
using RestSharp;
using DigiProj.Helpers;
using Digiproj.Shared.Dtos.Requests;

namespace DigiProj.Services
{
    public class MenuApiService : IMenuApiService
    {
        private readonly ITokenService _tokenService;

        private readonly RestClient _client;
        private readonly ApiConfiguration _apiConfig;

        public MenuApiService(IConfiguration configuration, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _apiConfig = configuration.GetSection(nameof(ApiConfiguration)).Get<ApiConfiguration>();
            _client = new RestClient(_apiConfig.BaseUrl);
        }
        public async Task<GlobalObjectListResponse<MsMenusResponse>> GetMenuController(MenuControllerRequest requestDto, CancellationToken cancellationToken)
        {

            var token = await _tokenService.CheckTokenAsync(cancellationToken);
            _client.AddAuthenticator(token);

            var request = new RestRequest(_apiConfig.UriGetMenuController, Method.POST);
            request.AddRequiredBody(requestDto);
            request.AddRequiredHeaders(_apiConfig);

            var response = await _client.ExecuteAsync(request, cancellationToken);
            response.CheckError(request);

            return response.GetContent<GlobalObjectListResponse<MsMenusResponse>>();
        }

    }
}
