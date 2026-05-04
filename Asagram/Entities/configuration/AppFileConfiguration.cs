using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Entities.configuration
{
    public class AppFileConfiguration : IEntityTypeConfiguration<AppFile>
    {
        public void Configure(EntityTypeBuilder<AppFile> builder)
        {
            builder.ToTable("Files");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.ContentType)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Data)
                .IsRequired()
                .HasColumnType("varbinary(max)");

            builder.HasOne(c => c.User)
                .WithOne(x => x.ProfileImage)
                .HasForeignKey<User>(x => x.ProfileImageId)
                .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
