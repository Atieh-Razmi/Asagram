using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public string? Description { get; set; }

        public ICollection<ProgramEntity> Programs { get; set; } = new List<ProgramEntity>();

        public ICollection<OverTime> OverTimes { get; set; } = new List<OverTime>(); 


    }
}
