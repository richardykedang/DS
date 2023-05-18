using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Requests.Project
{
    public class SearchProjectRequest: Filter
	{
		public string ProjectName { get; set; }
		
		[DefaultValue(0)]
		public int? Status { get; set; }

		public string Column { get; set; }
		public bool Y { get; set; }
	}

	public class DetailProjectRequest
	{
		public string ProjectId { get; set; }
	}
}
