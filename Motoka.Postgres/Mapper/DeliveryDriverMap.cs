using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoka.Postgres.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motoka.Postgres.Mapper
{
    internal static class DeliveryDriverMap
    {
        public static void Configure(EntityTypeBuilder<DelivererDto> builder)
        {

            builder.ToTable("delivery_driver");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
           .IsRequired()
           .HasMaxLength(255)
           .HasColumnName("name");

            builder.Property(e => e.Cnpj)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("cnpj");

            builder.Property(e => e.BirthDate)
                .IsRequired()
                .HasColumnName("birth_date");

            builder.Property(e => e.DriverLicenseNumber)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("driver_license_number");

            builder.Property(e => e.TypeCnh)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("type_cnh");
            builder.Property(e => e.ImageName)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("image_name");

            builder.HasIndex(e => e.Cnpj).IsUnique();
            builder.HasIndex(e => e.ImageName).IsUnique();
        }

    }
}
