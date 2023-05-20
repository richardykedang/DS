using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiproj.Shared.Entities
{
    public class MsMenu
    {
        public Int16 RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
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
    }


	public class MsMenus
	{
		public Int16 MenuId { get; set; } = 0!;
		public byte ParentId { get; set; } = 0!;
		public string MenuType { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public byte SeqNo { get; set; } = 0!;
		public bool IsActive { get; set; }
	}
}
