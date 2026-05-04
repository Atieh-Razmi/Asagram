using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.configuration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.ToTable("BankAccounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.BankName)
                .HasMaxLength(100);

            builder.Property(x => x.ShabaNumber)
                .HasColumnType("varchar(26)");

            builder.Property(x => x.CardNumber)
                .HasColumnType("varchar(16)");

            builder.Property(x => x.AccountNumber)
                .HasColumnType("varchar(30)");

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("varchar(15)");

            builder.Property(x => x.Address)
                .HasMaxLength(250);
        }
    }
}
