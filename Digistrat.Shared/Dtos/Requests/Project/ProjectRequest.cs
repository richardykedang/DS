using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Requests.Project
{
    public class SearchProjectRequest: Filter
	{
		public string ProjectName { get; set; }
		
		[DefaultValue(99)]
		public int? Status { get; set; } = 99;

		public string Column { get; set; }
		public bool Y { get; set; }
	}	
}
