namespace DigiProj.Configuration
{
	public class ApiConfiguration
	{
		public string BaseUrl { get; set; }
		public string ApiKey { get; set; }
		public string ApiSecret { get; set; }
		public string UriLogin { get; set; }
		public string UriLogout { get; set; }
		public string UriRefreshToken { get; set; }
		public string UriGetMaintenance { get; set; }
		public string UriCheckConnection { get; set; }
		public string UriGetProfileUser { get; set; }
		public string UriChangePassword { get; set; }
		public string UriGetUserMenus { get; set; }

		public string UriGetMenuController { get; set; }
		public string UriGetUserRoles { get; set; }

        public string UriGetProject { get; set; }
        public string UriSearchProject { get; set; }
		public string UriAutoCompleteStatus { get; set; }
		public string UriDetailProject { get; set; }
	}
}
