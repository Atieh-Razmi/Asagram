using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ProgramResponseDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public Guid ProjectId { get; set; }
    }
}
