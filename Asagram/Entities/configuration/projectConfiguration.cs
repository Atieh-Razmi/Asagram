using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class projectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(c => c.Description)
                .HasColumnType("nvarchar(max)");

            //builder.Property(c => c.StartTime)
            //    .IsRequired();

        }
    }
}
