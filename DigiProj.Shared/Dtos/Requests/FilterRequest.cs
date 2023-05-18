using DigiProj.Shared.Dtos.Requests.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Requests
{
	public class Filter
	{
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public List<Sort> Sort { get; set; }
	}

	public class FilterAutoComplete
	{
		public int limit { get; set; }
		public string q { get; set; }
	}
}
