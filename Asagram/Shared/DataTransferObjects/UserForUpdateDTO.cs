using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Shared.DataTransferObjects
{
    public record UserForUpdateDTO
    {
        [Required(ErrorMessage = "FirstName is Required.")]
        [MaxLength(50)]
        public string? FirstName {  get; set; }

        [Required(ErrorMessage = "LastName is Required.")]
        [MaxLength(50)]
        public string? LastName {  get; set; }

        [Required(ErrorMessage = "UserName is Required.")]
        [MaxLength(50)]
        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? NationalCode { get; set; }
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "UserUnit is Required.")]
        [MaxLength(50)]
        public string? UserUnit { get; set; }

        [Required(ErrorMessage = "RoleName is Required.")]

        public string? RoleName { get; set; }
        


    }
}
