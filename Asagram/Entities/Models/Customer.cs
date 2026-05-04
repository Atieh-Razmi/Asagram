using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<PhoneNumbers> PhoneNumbers { get; set; } = new List<PhoneNumbers>();
        
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? PostalCode { get; set; }
        [JsonIgnore]
        public City City { get; set; } = null!;
        public Guid CityId { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    }
}
