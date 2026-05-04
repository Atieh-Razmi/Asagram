using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }


        public string? Email { get; set; }
        public string? Description { get; set; }

        public ICollection<PhoneNumbers> PhoneNumbers { get; set; } = new List<PhoneNumbers>();
        [JsonIgnore]
        public City City { get; set; } = null!;
        public Guid CityId { get; set; }

        public Customer Customer { get; set; } = null!;
        public Guid CustomerId { get; set; }
    }
}
