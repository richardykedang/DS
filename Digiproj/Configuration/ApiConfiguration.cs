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

		public string UriGetUser { get; set; }

		public string UriGetDepartment { get; set; }
		public string UriGetProject { get; set; }
        public string UriSearchProject { get; set; }
		public string UriAutoCompleteStatus { get; set; }
		public string UriCreateProject { get; set; }
		public string UriUpdateProject { get; set; }
		public string UriDetailProject { get; set; }
		public string UriDeleteProject { get; set; }
        public string UriSearchUser { get; set; }
		public string UriTaskProjectTotal { get; set; }
        public string UriGetTaskEmployeeProject { get; set; }
        public string UriGetTaskProject { get; set; }
        public string UriGetMemberTaskProject { get; set; }
        public string UriCreateMember { get; set; }
		public string UriDeleteMember { get; set; }
        public string UriCreateTask { get; set; }
		public string UriEditTask { get; set; }
        public string UriDeleteTask { get; set; }
        public string UriAutoCompleteEmployeeProject { get; set; }
		public string UriGetTotalTaskByProject { get; set; }
		public string UriAutoCompleteProject { get; set; }
		public string UriGetTotalForDashboard { get; set; }
		public string UriSearchGetTotalTask { get; set; }
		


	}
}
