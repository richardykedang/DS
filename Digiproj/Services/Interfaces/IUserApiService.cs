using DigiProj.Shared.Dtos.Responses.MsUser;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Responses;

namespace DigiProj.Services.Interfaces
{
    public interface IUserApiService
	{
		Task<GlobalResponse> ChangePasswordAsync(ChangePasswordRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalObjectResponse<ProfilUserResponse>> GetProfilUserAsync(CancellationToken cancellationToken = default);
		Task<GlobalObjectListResponse<UserMenusResponse>> GetMenusAsync(CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<UserRolesResponse>> GetRolesAsync(CancellationToken cancellationToken = default);
    }
}
