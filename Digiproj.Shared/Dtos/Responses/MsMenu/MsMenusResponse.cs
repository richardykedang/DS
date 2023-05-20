using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiproj.Shared.Dtos.Responses.MsMenu
{
    public class MsMenusResponse
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
