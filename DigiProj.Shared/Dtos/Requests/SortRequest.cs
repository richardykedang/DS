using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Requests
{
	public class Sort
	{
		public string Field { get; set; }

		public bool IsAscending { get; set; }
	}
}
