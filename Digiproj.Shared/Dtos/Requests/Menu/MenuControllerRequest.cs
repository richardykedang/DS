using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiproj.Shared.Dtos.Requests
{
    public class MenuControllerRequest
    {
        [Required]
		public string ControllerName { get; set; }
	}
}
