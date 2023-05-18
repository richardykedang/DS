using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Requests
{
	public class LoginRequest
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}

	public class UsernameRequest
	{
		public string Username { get; set; }
	}

	public class RefreshTokenRequest
	{
		[Required]
		public string RefreshToken { get; set; }
	}
}
