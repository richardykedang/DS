using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Entities
{
	public class ProfileUser
	{
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Nip { get; set; } = null!;
		public string Username { get; set; } = null!;
		public string Path_signature { get; set; } = null!;
		public bool IsActive { get; set; }
		public bool IsFirstTime { get; set; }
		public string Role { get; set; } = null!;
	}
}
