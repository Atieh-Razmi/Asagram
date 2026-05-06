using Entities.Enums;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ToTable("Leaves");
            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.LeaveTime)
                .IsRequired();

            builder.Property(c => c.LeaveType)
                .IsRequired();

            builder.Property(c => c.LeaveStatus)
                .IsRequired();

            builder.Property(c=>c.FromDate)
                .HasColumnType("datetime2")
                .IsRequired() ;

            builder.Property(c => c.ToDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasMaxLength(250)
                .HasColumnType("nvarchar(250)");

            builder.Property(c => c.Duration)
                .HasColumnType("decimal(5,2)");

            builder.HasOne(c => c.User)
                .WithMany(x => x.Leaves)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
