using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Configuration.Constants
{
	public class JwtClaimTypeConsts
	{
		public const string EmployeeId = "employee_id";
		public const string CollectorName = "collector_name";
		public const string IsLogin = "is_login";
		public const string LastLogin = "last_login";
		public const string LastResetPassword = "last_reset_password";
		public const string LastChangePassword = "last_change_password";
		public const string IsForceChangePassword = "is_force_change_password";

		public const string Name = "name";
		public const string GivenName = "given_name";
		public const string FamilyName = "family_name";
		public const string MiddleName = "middle_name";
		public const string NickName = "nickname";
		public const string PreferredUserName = "preferred_username";
		public const string Profile = "profile";
		public const string Picture = "picture";
		public const string WebSite = "website";
		public const string Email = "email";
		public const string Gender = "gender";
		public const string BirthDate = "birthdate";
		public const string PhoneNumber = "phone_number";
		public const string Address = "address";
		public const string ClientId = "client_id";
		public const string Scope = "scope";
		public const string Role = "role";
	}
}
