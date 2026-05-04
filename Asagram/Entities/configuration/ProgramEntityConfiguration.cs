using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class ProgramEntityConfiguration : IEntityTypeConfiguration<ProgramEntity>
    {
        public void Configure(EntityTypeBuilder<ProgramEntity> builder)
        {
            builder.ToTable("Programs");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.HasOne(c => c.Project)
                .WithMany(v => v.Programs)
                .HasForeignKey(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
