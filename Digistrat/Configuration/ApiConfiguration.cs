namespace Digistrat.Configuration
{
	public class ApiConfiguration
	{
		public string BaseUrl { get; set; }
		public string ApiKey { get; set; }
		public string ApiSecret { get; set; }
		public string UriLogin { get; set; }
		public string UriRefreshToken { get; set; }
		public string UriGetMaintenance { get; set; }
		public string UriCheckConnection { get; set; }
		public string UriGetProfileUser { get; set; }
		public string UriChangePassword { get; set; }
        public string UriGetProject { get; set; }
        public string UriSearchProject { get; set; }
    }
}
