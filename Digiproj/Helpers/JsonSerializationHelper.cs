using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Digistrat.Helpers
{
	public static class JsonSerializationHelper
	{
		private static readonly SnakeCaseNamingStrategy _snakeCaseNamingStrategy
			= new();

		public static readonly JsonSerializerSettings SnakeCaseSettings = new()
		{
			ContractResolver = new DefaultContractResolver { NamingStrategy = _snakeCaseNamingStrategy },
			NullValueHandling = NullValueHandling.Ignore
		};

		public static string ToSnakeCase<T>(this T instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(paramName: nameof(instance));
			}

			return JsonConvert.SerializeObject(instance, SnakeCaseSettings);
		}


		public static string ToSnakeCase(this string @string)
		{
			if (@string == null)
			{
				throw new ArgumentNullException(paramName: nameof(@string));
			}

			return _snakeCaseNamingStrategy.GetPropertyName(@string, false);
		}
	}
}
