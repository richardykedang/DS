namespace DigiProj.Configuration
{
	public class JwtConfiguration
	{
		public bool RequireHttpsMetadata { get; set; }
		public bool SaveToken { get; set; }
		public bool ValidateIssuer { get; set; }
		public bool ValidateAudience { get; set; }
		public bool ValidateLifetime { get; set; }
		public bool ValidateIssuerSigningKey { get; set; }
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Key { get; set; }
		public long TokenLifetime { get; set; }
	}
}
