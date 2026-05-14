using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class User
    {
        public Guid  Id {  get; set; }

        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public Gender? Gender { get; set; }

        public string? NationalCode { get; set; }

        public Unit? Unit { get; set; } 
        public Guid? UnitId { get; set; }

        //public string? UserUnit { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

        public DateTime StartTime { get; set; }
        public string? IP { get; set; }

        public bool IsActive { get; set; } = true;

        public bool Status { get; set; }
        public DateTime EndTime { get; set; }

        public AppFile? ProfileImage { get; set; }
        public Guid? ProfileImageId { get; set; }
        public ICollection<Leave> Leaves { get; set; }
        public ICollection<OverTime> OverTimes { get; set; } = new List<OverTime>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();

        public ICollection<Unit> ManagedUnits { get; set; } = new List<Unit>();
        public ICollection<WorkLog> WorkLogs { get; set; } = new List<WorkLog>(); 

    }
}
