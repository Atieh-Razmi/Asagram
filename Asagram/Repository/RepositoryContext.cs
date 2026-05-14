using Application.Interfaces;
using Entities.configuration;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryContext : DbContext, IRepositoryContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options): base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<AppFile> AppFiles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProgramEntity> Programs { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        public DbSet<OverTime> OverTimes { get; set; }

        public DbSet<Report> Reports { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<LeaveStep> LeaveSteps { get; set; }
       
        public DbSet<WorkLog> WorkLogs { get; set; }
        public DbSet<OverTimeStep> OverTimeSteps { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserRole>()
               .HasOne(x => x.Role)
               .WithMany(r => r.UserRoles)
               .HasForeignKey(x => x.RoleId);

            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AppFileConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new projectConfiguration());
            modelBuilder.ApplyConfiguration(new LeaveConfiguration());
            modelBuilder.ApplyConfiguration(new OverTimeConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration() );
            modelBuilder.ApplyConfiguration(new UnitConfiguration() );


        }
    }
}
