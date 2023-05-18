using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Responses.MsAssignTo
{
    public class AssignToResponse
    {
        public int IdAssign { get; set; }
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
