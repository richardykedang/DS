using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Responses;

namespace Digistrat.Services.Interfaces
{
	public interface IAuthenticationApiService
	{
		Task<TokenResponse> LoginAsync(LoginRequest requestDto, CancellationToken cancellationToken = default);
		Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalObjectResponse<MaintenanceResponse>> GetMaintenanceAsync(CancellationToken cancellationToken = default);
	}
}
