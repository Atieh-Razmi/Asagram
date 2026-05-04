using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record ProfileDTO
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string UserName { get; init; }
        public string NationalCode { get; init; }
        public string UserUnit { get; init; }
        public string RoleName { get; init; }
        public string PhoneNumber { get; init; }
        public Gender Gender { get; init; }

        public Guid? ProfileImageId { get; init; }
    }
}
