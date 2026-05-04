using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Entities.Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Province Province { get; set; } = null!;
        public Guid ProvinceId { get; set; }

        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
