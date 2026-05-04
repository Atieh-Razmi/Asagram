using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ContactDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<string> Phones { get; set; } = new();

        public Guid CityId { get; set; }
        

        public string? Description { get; set; }
        public string? Email { get; set; }
    }
}
