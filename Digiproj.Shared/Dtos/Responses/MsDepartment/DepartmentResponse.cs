using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiproj.Shared.Dtos.Responses.MsDepartment
{
	public class DepartmentResponse
	{	
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
	}
}
