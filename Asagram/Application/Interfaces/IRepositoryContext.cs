using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IRepositoryContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Province> Provinces { get; set; }

        DbSet<BankAccount> BankAccounts { get; set; }

        DbSet<AppFile> AppFiles { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Contact> Contacts { get; set; }

        DbSet<Project> Projects { get; set; }
        DbSet<ProgramEntity> Programs { get; set; }
        DbSet<Leave> Leaves { get; set; }
        DbSet<OverTime> OverTimes {  get; set; }

        DbSet<Report> Reports { get; set; }

        DbSet<Unit> Units { get; set; }
        DbSet<LeaveStep> LeaveSteps { get; set; }
       
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        
    }
}
