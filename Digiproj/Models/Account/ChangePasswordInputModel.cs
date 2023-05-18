using System.ComponentModel.DataAnnotations;

namespace Digistrat.Models.Account
{
	public class ChangePasswordInputModel
	{
		public string Username { get; set; }
		public string OldPassword { get; set; }
		public string Password { get; set; }
	}
}
