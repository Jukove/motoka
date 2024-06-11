using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoka.Postgres.Dtos;

namespace Motoka.Postgres.Mapper
{
    public static class VehiclesMap
    {
        public static void Configure(EntityTypeBuilder<VehiclesDto> builder)
        {
            builder.ToTable("vehicles");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.HasKey(e => e.Id).HasName("id");
            builder.Property(e => e.Placa).HasColumnName("placa")
                   .IsRequired()
                   .HasMaxLength(8);
            builder.Property(e => e.Modelo).HasColumnName("modelo")
                   .IsRequired()
                   .HasMaxLength(15);
            builder.Property(e => e.Ano).HasColumnName("ano")
                   .IsRequired()
                   .HasMaxLength(6);
            builder.Property(e => e.IsAvailable).HasColumnName("is_available")
                   .IsRequired();

            builder.HasIndex(e => e.Placa).IsUnique();

            //builder.HasMany(e => e.AnotherEntities)
            //       .WithOne(e => e.YourEntity)
            //       .HasForeignKey(e => e.YourEntityId);
        }
    }

}
