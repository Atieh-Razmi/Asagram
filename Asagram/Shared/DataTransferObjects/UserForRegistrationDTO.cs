using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UserForRegistrationDTO
    {
        //public Guid Id { get; set; }
        [Required(ErrorMessage = "FirstName is Required.")]
        [MaxLength(50)]

        public string? FirstName { get; set; }

        [Required(ErrorMessage = "LastName is Required.")]
        [MaxLength(50)]

        public string? LastName { get; set; }

        [Required(ErrorMessage = "UserName is Required.")]
        [MaxLength(50)]

        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? NationalCode { get; set; }
        public Gender? Gender { get; set; }
        [Required(ErrorMessage = "UserUnit is Required.")]
        
        public Guid UnitId{ get; set; }

        public string? RoleName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]

        public string? Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is Required.")]

        public string? ConfirmPassword { get; set; }
    }
}
