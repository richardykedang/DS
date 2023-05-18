using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigiProj.Shared.Entities.MsUser
{
	public class MsUser
	{
		public string Username { get; set; }
		public string EmployeeId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime? ExpiredDate { get; set; }
		public DateTime? LastResetPassword { get; set; }
		public DateTime? LastChangePassword { get; set; }
		[Display(Name = "Last Login")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
		public DateTime LastLogin { get; set; }
		public bool IsLogin { get; set; }
		public bool IsResign { get; set; }
		public bool IsActive { get; set; }
		public bool IsForceChangePassword { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string UpdatedBy { get; set; }

	}
}
