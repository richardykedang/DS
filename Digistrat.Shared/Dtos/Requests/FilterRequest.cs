using Digistrat.Shared.Dtos.Requests.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Requests
{
	public class Filter
	{
		public int PageSize { get; set; }
		public int PageIndex { get; set; }
		public List<Sort> Sort { get; set; }
	}
}
