using System.ComponentModel;

namespace DigiProj.Models.Users
{
	public class SearchUserInputModel : Filter
	{

		public string EmployeeId { get; set; }
		public string Name { get; set; }
		public string UserName { get; set; }
		public int[] RoleIds { get; set; }
		[DefaultValue(0)]
		public bool IsActive { get; set; }

		public string Column { get; set; }
		public bool Y { get; set; }
	}
}
