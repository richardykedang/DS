﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Digistrat.Models.Account
{
	public class LoginInputModel
	{
		[Required(ErrorMessage = "Username Harus Diisi.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Kata sandi Harus Diisi.")]
		[Display(Name = "Password")]
		public string Password { get; set; }
		public string ReturnUrl { get; set; }


	}
}
