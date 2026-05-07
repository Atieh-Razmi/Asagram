using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class OverTimeConfiguration : IEntityTypeConfiguration<OverTime>
    {
        public void Configure(EntityTypeBuilder<OverTime> builder)
        {
            builder.ToTable("OverTimes");
            builder.HasKey(c => c.Id);

            builder.Property(c=>c.Id)
              .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Description)
                .HasMaxLength(250)
                .IsRequired()
                .HasColumnType("nvarchar(250)");

            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(c => c.OverTimeStatus)
                .IsRequired();

            builder.Property(c => c.Duration)
                .IsRequired();

            builder.HasOne(c=> c.User)
                .WithMany(x=>x.OverTimes)
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Project)
                .WithMany(x => x.OverTimes)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
