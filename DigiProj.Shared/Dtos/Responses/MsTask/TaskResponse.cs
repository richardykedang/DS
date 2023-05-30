using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Responses.MsTask
{
	public class TaskResponse
	{
		public Guid Id { get; set; }
		public int TaskId { get; set; }
		public string TaskName { get; set; }
		public string ProjectId { get; set; }
		public string TaskOwner { get; set; }
		public int Status { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }
		public bool? IsActive { get; set; }
		public bool? IsDelete { get; set; }
	}

	public class TaskDetailResponse
	{
        public string EmployeeId { get; set; }
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TotalTask { get; set; }
        public string RoleProject { get; set; }
    }

    public class TaskTotalResponse
    {
        public int Task { get; set; }
        public int Block { get; set; }
        public int Done { get; set; }
        public int TotalTask { get; set; }
    }

    public class TaskProjectesponse
    {
        public Guid Id { get; set; }
        public string ProjectId { get; set; }
        public string EmployeeId { get; set; }
        public string ProjectName { get; set; }
        public string TaskName { get; set; }
        public int Status { get; set; }
        public string Priority { get; set; }
        public string Fullname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
