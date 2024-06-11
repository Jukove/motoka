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
    public class OrderMap
    {
        public static void Configure(EntityTypeBuilder<OrderDto> builder)
        {

            builder.ToTable("orders");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Status)
           .IsRequired()
           .HasMaxLength(255)
           .HasColumnName("status");

            builder.Property(e => e.CreationDate)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("creation_date");

            builder.Property(e => e.Fare)
                .IsRequired()
                .HasColumnName("delivery_cost");

        }
    }
}
