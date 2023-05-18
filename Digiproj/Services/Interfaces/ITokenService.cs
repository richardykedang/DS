using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Responses;
using System.IdentityModel.Tokens.Jwt;

namespace Digistrat.Services.Interfaces
{
    public interface ITokenService
	{
		Task<TokenResponse> CheckTokenAsync(CancellationToken cancellationToken = default);
		Task<TokenResponse> GenerateTokenAsync(LoginRequest requestDto, CancellationToken cancellationToken = default);
		Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest requestDto, CancellationToken cancellationToken = default);
		JwtSecurityToken GetToken();
	}
}
