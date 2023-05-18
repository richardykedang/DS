using DigiProj.Configuration;
using DigiProj.Helpers;
using DigiProj.Services.Interfaces;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Responses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DigiProj.Services
{
	public class TokenService : ITokenService
	{
			private readonly IAuthenticationApiService _apiService;
			private readonly IHttpContextAccessor _contextAccessor;

			private readonly JwtConfiguration _jwtConfig;
			private TokenResponse _token;

			public TokenService(IConfiguration configuration, IAuthenticationApiService apiService, IHttpContextAccessor contextAccessor)
			{
				_apiService = apiService;
				_contextAccessor = contextAccessor;
				_jwtConfig = configuration.GetSection(nameof(JwtConfiguration)).Get<JwtConfiguration>();
			}

			public async Task<TokenResponse> CheckTokenAsync(CancellationToken cancellationToken)
			{
				_token ??= _contextAccessor.HttpContext?.GetToken();

				if (_token == null)
					throw new SecurityTokenException("Token is not found");

				if (_token.ExpiredTime < DateTime.Now)
					await RefreshTokenAsync(new RefreshTokenRequest() { RefreshToken = _token.RefreshToken }, cancellationToken);

				return _token;
			}

			public async Task<TokenResponse> GenerateTokenAsync(LoginRequest requestDto, CancellationToken cancellationToken)
			{
				var response = await _apiService.LoginAsync(requestDto, cancellationToken);

				if (!response.Error)
				{
					_token = response;

					//Save token to cookies
					_contextAccessor.HttpContext?.Response.Cookies.SaveToken(_token);
					return _token;
				}

				return response;

			}

			public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest requestDto, CancellationToken cancellationToken)
			{
				var response = await _apiService.RefreshTokenAsync(requestDto, cancellationToken);

				if (!response.Error)
				{
					_token = response;

					//Save token to cookies
					_contextAccessor.HttpContext?.Response.Cookies.SaveToken(_token);
				}

				return _token;
			}
			public JwtSecurityToken GetToken()
			{
				_token ??= _contextAccessor.HttpContext?.GetToken();

				var tokenHandler = new JwtSecurityTokenHandler();
				var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_jwtConfig.Key));
				tokenHandler.ValidateToken(_token.Token,
					new TokenValidationParameters
					{
						ValidateIssuer = _jwtConfig.ValidateIssuer,
						ValidateAudience = _jwtConfig.ValidateAudience,
						ValidIssuer = _jwtConfig.Issuer,
						ValidAudience = _jwtConfig.Audience,
						ValidateIssuerSigningKey = _jwtConfig.ValidateIssuerSigningKey,
						IssuerSigningKey = new SymmetricSecurityKey(hmac.Key)
					}, out SecurityToken validatedToken);


				return (JwtSecurityToken)validatedToken;
			}
	}
	
}
