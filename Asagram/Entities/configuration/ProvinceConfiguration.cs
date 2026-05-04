using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Province");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60);
            //builder.HasMany(p => p.cities)
            //    .WithOne(c => c.Province)
            //    .HasForeignKey(c => c.ProvinceId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
