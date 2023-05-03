using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Digistrat.Models.Account
{
	public class LoginInputModel
	{
		[Required(ErrorMessage = "Username Harus Diisi.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Kata sandi Harus Diisi.")]
		[Display(Name = "Password")]
		[StringLength(20, MinimumLength = 8, ErrorMessage = "Minimal harus 8 karakter dan karakter harus mengandung huruf besar, huruf kecil, angka & simbol.")]
		[RegularExpression(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\s])^.{8,}$", ErrorMessage = "Minimal harus 8 karakter dan karakter harus mengandung huruf besar, huruf kecil, angka & simbol.")]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }


	}
}
