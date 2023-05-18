using Digistrat.Configuration;
using Digistrat.Shared.Helpers;

namespace Digistrat.Helpers
{
		public static class SecurityHelper
		{
			public static string PasswordKey { get; set; }
			public static string OthersKey { get; set; }
			public static string CookiesKey { get; set; }
			public static bool IsAdded { get; set; }

			public static void AddSecurityKeys(this IConfiguration configuration)
			{
				var pathConfig = configuration.GetSection(nameof(PathConfiguration)).Get<PathConfiguration>();
				var text = File.ReadAllText($"{pathConfig.KeysPath}/{nameof(PasswordKey)}.txt").Trim();
				PasswordKey = text;

				text = File.ReadAllText($"{pathConfig.KeysPath}/{nameof(OthersKey)}.txt").Trim();
				OthersKey = text;

				text = File.ReadAllText($"{pathConfig.KeysPath}/{nameof(CookiesKey)}.txt").Trim();
				CookiesKey = text;

				IsAdded = true;
			}
			public static string GetPasswordEncrypted(string passwordPlain)
			{
				var passwordEncrypted = Security.RijndaelEncrypt(passwordPlain, PasswordKey);
				return passwordEncrypted;
			}
			public static string GetCookiesEncrypted(string cookiesPlain)
			{
				var cookiesEncrypted = Security.RijndaelEncrypt(cookiesPlain, CookiesKey);
				return cookiesEncrypted;
			}
			public static string GetCookiesDecrypted(string cookiesEncrypted)
			{
				var cookiesDecrypted = Security.RijndaelDecrypt(cookiesEncrypted, CookiesKey);
				return cookiesDecrypted;
			}
			public static string Decrypt(this string text)
			{
				text = Security.RijndaelDecrypt(text, OthersKey);
				return text;
			}

			public static string Encrypt(this string text)
			{
				text = Security.RijndaelEncrypt(text, OthersKey);
				return text;
			}
		}
}

