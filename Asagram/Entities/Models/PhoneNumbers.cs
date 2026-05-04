using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class PhoneNumbers
    {
        public Guid Id { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public Guid? ContactId { get; set; }
        [JsonIgnore]
        public Contact? Contact { get; set; } = null!;

        public Guid? CustomerId { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; } = null!;
    }
}
