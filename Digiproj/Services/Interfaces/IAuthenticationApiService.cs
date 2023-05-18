using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Responses;

namespace DigiProj.Services.Interfaces
{
	public interface IAuthenticationApiService
	{
		Task<TokenResponse> LoginAsync(LoginRequest requestDto, CancellationToken cancellationToken = default);
		Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalObjectResponse<MaintenanceResponse>> GetMaintenanceAsync(CancellationToken cancellationToken = default);
	}
}
