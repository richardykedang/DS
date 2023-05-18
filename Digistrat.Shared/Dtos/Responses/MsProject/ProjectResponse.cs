using Digistrat.Shared.Dtos.Responses.MsAssignTo;
using Digistrat.Shared.Dtos.Responses.MsTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Responses.MsProject
{
    public class ProjectResponse
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
		public string AesProj { get; set; }
		public string Approval { get; set; }
		public string ProjectName { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public int MemberTotal { get; set; }
        public List<AssignToResponse> AssignTo { get; set; }

    }
}
