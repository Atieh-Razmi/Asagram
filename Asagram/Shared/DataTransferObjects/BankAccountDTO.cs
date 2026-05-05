using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record BankAccountDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? BankName { get; set; }
        public string? ShabaNumber { get; set; }
        public string? CardNumber { get; set; }
        public string? AccountNumber { get; set; }

    }
}
