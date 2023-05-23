using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Responses.MsUser
{
    public class UserRolesResponse
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public class UserMenusResponse
    {
		public Int16 RoleId { get; set; }
		public string RoleName { get; set; } = null!;
		public Guid UserId { get; set; }
		public string UserName { get; set; } = null!;
		public byte MenuParentId { get; set; } = 0!;
		public string MenuParentName { get; set; } = null!;
		public Int16 MenuId { get; set; } = 0!;
		public string MenuName { get; set; } = null!;
		public string MenuType { get; set; } = null!;
		public string Description { get; set; } = null!;
		public byte SeqNo { get; set; } = 0!;
		public string Controller { get; set; } = null!;
		public string Action { get; set; } = null!;
		public string Icon { get; set; } = null!;

		public bool IsCreate { get; set; }
		public bool IsEdit { get; set; }
		public bool IsRead { get; set; }
		public bool IsDelete { get; set; }
		public bool IsUpload { get; set; }
	}

	public class ProfilUserResponse
    {
		public string Name { get; set; }
		public string Email { get; set; }
		public string Nip { get; set; }
		public string Username { get; set; }
		public string Path_signature { get; set; }
		public bool IsActive { get; set; }
		public bool IsFirstTime { get; set; }
		public string Role { get; set; }

	}

	public class UserResponse
	{
		public Guid Id { get; set; }
		public string EmployeeId { get; set; }

	}
}
