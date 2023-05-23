using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Responses.MsAssignTo
{
    public class AssignToResponse
    {
        public int IdAssign { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }

	public class OwnerProjectResponse
	{
		public string EmployeeId { get; set; }
		public string Name { get; set; }
	}
}
