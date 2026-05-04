using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? BankName { get; set; }
        public string? ShabaNumber { get; set; }
        public string? CardNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? AccountNumber {  get; set; }
    }
}
