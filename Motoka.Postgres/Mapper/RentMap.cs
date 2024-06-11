using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoka.Postgres.Dtos;

namespace Motoka.Postgres.Mapper
{
    internal static class RentMap
    {
        public static void Configure(EntityTypeBuilder<RentDto> builder)
        {
            builder.ToTable("rent");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.StartDate)
                .IsRequired()
                .HasColumnName("start_date")
                .HasColumnType("date");

            builder.Property(e => e.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("date");

            builder.Property(e => e.VehiclePlate)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("vehicle_plate");

            builder.Property(e => e.DeliveryDriverCnpj)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("delivery_driver_cnpj");

            builder.Property(e => e.TotalCost)
               .IsRequired()
               .HasColumnName("total_cost");

            builder.Property(e => e.Fine)
               .HasColumnName("fine");

            builder.Property(e => e.Range)
               .IsRequired()
               .HasMaxLength(14)
               .HasColumnName("range");

            builder.Property(e => e.ExpectedDate)
               .IsRequired()
               .HasMaxLength(14)
               .HasColumnName("expected_date");

            builder.HasOne(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehiclePlate)
                 .HasPrincipalKey(e => e.Placa)
                .HasConstraintName("fk_vehicle_plate");

            builder.HasOne(e => e.DeliveryDriver)
                .WithMany()
                .HasForeignKey(e => e.DeliveryDriverCnpj)
                .HasPrincipalKey(e => e.Cnpj)
                .HasConstraintName("fk_delivery_driver_cnpj");
        }
    }
}
