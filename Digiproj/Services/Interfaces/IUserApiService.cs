using DigiProj.Shared.Dtos.Responses.MsUser;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Requests.Project;
using Digiproj.Shared.Dtos.Requests.Users;

namespace DigiProj.Services.Interfaces
{
    public interface IUserApiService
	{
		Task<GlobalObjectListResponse<UserResponse>> GetUsers(CancellationToken cancellationToken = default);
		Task<GlobalResponse> ChangePasswordAsync(ChangePasswordRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalObjectResponse<ProfilUserResponse>> GetProfilUserAsync(CancellationToken cancellationToken = default);
		Task<GlobalObjectListResponse<UserMenusResponse>> GetMenusAsync(CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<UserRolesResponse>> GetRolesAsync(CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<UserResponse>> GetSearchUser(UserRequest requestDto, CancellationToken cancellationToken = default);
    }
}
