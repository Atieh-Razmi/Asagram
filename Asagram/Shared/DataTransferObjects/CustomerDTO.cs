using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record CustomerDTO
    {    
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PostalCode { get; set; }

        public Guid CityId { get; set; }
        
        public List<string> Phones { get; set; } = new();
    }
}
