using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UpdateUnitDTO
    {
        public Guid ManagerId { get; set; }
    }
}
