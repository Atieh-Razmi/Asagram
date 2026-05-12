using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units");
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Users)
                .WithOne(x => x.Unit)
                .HasForeignKey(x => x.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(c=>c.Manager)
                .WithMany(x=>x.ManagedUnits)
                .HasForeignKey(c=>c.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ParentUnit)
                .WithMany(c => c.ChildUnits)
                .HasForeignKey(c => c.ParentUnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
