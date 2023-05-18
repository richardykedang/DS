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
}
