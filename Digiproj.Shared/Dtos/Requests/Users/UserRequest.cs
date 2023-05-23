using DigiProj.Shared.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiproj.Shared.Dtos.Requests.Users
{
	public class UserRequest : Filter
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
