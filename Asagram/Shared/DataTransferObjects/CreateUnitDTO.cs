using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CreateUnitDTO
    {
        public string Name { get; set; } = null!;
        public int DisplayOrder { get; set; }
        public Guid? ManagerId { get; set; }
        public Guid? ParentUnitId { get; set; }



    }
}
