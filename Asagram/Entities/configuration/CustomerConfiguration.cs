using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasMany(c => c.PhoneNumbers)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Address)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Email)
               .HasColumnType("varchar(150)");

            builder.Property(c => c.PostalCode)
               .HasColumnType("varchar(50)");

            builder.HasOne(c => c.City)
                .WithMany(p => p.Customers)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
