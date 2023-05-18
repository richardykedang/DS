using Digistrat.Models.Project;

namespace Digistrat.Models
{
	public class Filter
	{
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public List<Sort> Sort { get; set; }
	}

	public class FilterAutoCompleteModel
	{
		public int limit { get; set; }
		public string q { get; set; }
	}
}
