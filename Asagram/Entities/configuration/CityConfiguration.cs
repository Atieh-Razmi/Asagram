using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
    
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(c => c.ProvinceId)
                .IsRequired();

            builder.HasOne(c => c.Province)
                .WithMany(p => p.cities)
                .HasForeignKey(c => c.ProvinceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
