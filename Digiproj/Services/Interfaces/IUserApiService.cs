using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Responses;
using Digistrat.Shared.Dtos.Responses.MsUser;

namespace Digistrat.Services.Interfaces
{
    public interface IUserApiService
	{
		Task<GlobalResponse> ChangePasswordAsync(ChangePasswordRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalObjectResponse<ProfilUserResponse>> GetProfilUserAsync(CancellationToken cancellationToken = default);
		
	}
}
