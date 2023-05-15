using Digistrat.Shared.Dtos.Requests.Project;
using System.ComponentModel;

namespace Digistrat.Models.Project
{
	public class SearchProjectInputModel: Filter
	{

		public string ProjectName { get; set; }

		[DefaultValue(99)]
		public int? Status { get; set; } = 99;
		public string Column { get; set; }
		public bool Y { get; set; }
	}

}
