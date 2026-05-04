using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ProgramForCreateDTO
    {
        public string Title { get; set; } = null!;
        public Guid ProjectId { get; set; }
    }
}
