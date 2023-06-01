using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Responses
{
    public class TextModelResponse
    {
        public int id { get; set; }
        public string name { get; set; }
    }

	public class TextModelProjectResponse
	{
		public string ProjectId { get; set; }
		public string ProjectName { get; set; }
	}
}
