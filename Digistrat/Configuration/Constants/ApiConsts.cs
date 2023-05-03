namespace Digistrat.Configuration.Constants
{
	public class ApiConsts
	{
		public const string ContentType = "application/json";
		public const string TokenPrefix = ".AspNetCore.";

		//milisecond
		public const int TimeoutHigh = 3600000; //1 hour
		public const int TimeoutMedium = 1800000; //30 menit
		public const int TimeoutNormal = 60000; //1 menit
	}
}
