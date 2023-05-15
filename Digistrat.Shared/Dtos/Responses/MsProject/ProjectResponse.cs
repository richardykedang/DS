using Digistrat.Shared.Dtos.Responses.MsAssignTo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Responses.MsProject
{
    public class ProjectResponse
    {
		public Guid Id { get; set; }
		public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
		public DateTime EndDate { get; set; }
		public string CreatedBy { get; set; }
		public int MemberTotal { get; set; }
		public List<AssignToResponse> AssignTo { get; set; }

    }
}
