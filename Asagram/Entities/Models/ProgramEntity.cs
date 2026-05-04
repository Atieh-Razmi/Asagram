using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ProgramEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public Project Project { get; set; } = null!;
        public Guid ProjectId { get; set; }

    }
}
