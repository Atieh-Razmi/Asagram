using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.FirstName)
                .HasMaxLength(60);

            builder.Property(c => c.LastName)
                .HasMaxLength(60);

            builder.Property(c => c.Email)
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .HasMaxLength(250);


            builder.HasMany(c => c.PhoneNumbers)
                .WithOne(p => p.Contact)
                .HasForeignKey(p => p.ContactId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(c => c.City)
                .WithMany(p => p.Contacts)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Customer)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
