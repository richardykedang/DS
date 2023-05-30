using Digiproj.Shared.Dtos.Responses.MsDepartment;
using DigiProj.Shared.Dtos.Responses.MsAssignTo;
using DigiProj.Shared.Dtos.Responses.MsTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Responses.MsProject
{
    public class ProjectAutoCompleteResponse
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
    }

        public class ProjectResponse
    {
        public string Id { get; set; }
        public string ProjectId { get; set; }
		public string AesProj { get; set; }
		public string ProjectName { get; set; }
        public string EmployeeId { get; set; }
        public string ProjectOwner { get; set; }
        public string Summary { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
		public int Status { get; set; }
		public bool? IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedBy { get; set; }
        public int MemberTotal { get; set; }
        public List<AssignToResponse> AssignTo { get; set; }

    }
}
