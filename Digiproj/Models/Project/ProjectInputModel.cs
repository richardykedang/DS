using Digistrat.Shared.Dtos.Requests.Project;
using System.ComponentModel;

namespace Digistrat.Models.Project
{
	public class SearchProjectInputModel: Filter
	{

		public string ProjectName { get; set; }

		[DefaultValue(0)]
		public int? Status { get; set; }
		public string Column { get; set; }
		public bool Y { get; set; }
	}

	public class DetailProjectInputModel
	{
		public string ProjectId { get; set; }
	}
}
