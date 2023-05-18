using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Entities
{
	public class ProfileUser
	{
		public string Name { get; set; } = null!;
		public string Nip { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Role { get; set; } = null!;
	}
}
