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
    public class OrderNotificationMap
    {
        public static void Configure(EntityTypeBuilder<OrderNotificationDto> builder)
        {

            builder.ToTable("order_notification");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.DeliveryDriverCnpj)
           .IsRequired()
           .HasMaxLength(14)
           .HasColumnName("delivery_driver_cnpj");

            builder.Property(e => e.SentDate)
                .IsRequired()                
                .HasColumnName("sent_date");

            builder.Property(e => e.Message)
                .HasColumnName("message");

            builder.Property(e => e.OrderId)
                .IsRequired()
                .HasColumnName("order_id");

            builder.Property(e => e.Accept)
                .IsRequired()
                .HasColumnName("is_accept");


            builder.HasOne(e => e.Order)
                .WithMany()
                .IsRequired()
                .HasForeignKey(e => e.OrderId)
                .HasConstraintName("fk_ordernotifications_order");

            builder.HasOne(e => e.DeliveryDriver)
                .WithMany()
                .IsRequired()
                .HasPrincipalKey(e => e.Cnpj)
                .HasForeignKey(e => e.DeliveryDriverCnpj)
                .HasConstraintName("fk_ordernotifications_deliverydriver");

        }
    }
}
