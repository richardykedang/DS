using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digistrat.Shared.Dtos.Responses.MsUser
{
    public class UserMenusResponse
    {
        public short RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        //public byte MenuParentId { get; set; } = 0!;
        //public string MenuParentName { get; set; } = null!;
        public short MenuId { get; set; } = 0!;
        public string MenuName { get; set; } = null!;
        public string MenuType { get; set; } = null!;
        //public string Description { get; set; } = null!;
        //public byte SeqNo { get; set; } = 0!;
        public string Controller { get; set; } = null!;
        public string Action { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }

	public class ProfilUserResponse
    {
        public string Name { get; set; }
		public string Nip { get; set; }
        public string Email { get; set; }

    }
}
