using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Responses;
using Digistrat.Shared.Dtos.Responses.MsUser;

namespace Digistrat.Services.Interfaces
{
    public interface IUserApiService
	{
		//Task<GlobalResponse> ChangePasswordAsync(ChangePasswordRequest requestDto, CancellationToken cancellationToken = default);
		//Task<GlobalObjectResponse<SystemControlResponse>> GetSystemControlAsync(CancellationToken cancellationToken = default);
		//Task<GlobalObjectListResponse<UserRolesResponse>> GetRolesAsync(CancellationToken cancellationToken = default);
		//Task<GlobalObjectListResponse<UserMenusResponse>> GetMenusAsync(CancellationToken cancellationToken = default);
		Task<GlobalObjectResponse<ProfilUserResponse>> GetProfilUserAsync(CancellationToken cancellationToken = default);
		//Task<GlobalObjectListResponse<MsUserResponse>> GetUsers(CancellationToken cancellationToken = default);
		
	}
}
