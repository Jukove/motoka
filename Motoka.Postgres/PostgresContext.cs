using Microsoft.EntityFrameworkCore;
using Motoka.Postgres.Dtos;
using Motoka.Postgres.Mapper;
using System.Reflection;

namespace Motoka.Postgres
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {
            
        }

        public DbSet<VehiclesDto> MotoCadastro {  get; set; }
        public DbSet<DelivererDto> Deliverer { get; set; }
        public DbSet<RentDto> Rent { get; set; }
        public DbSet<OrderDto> Order { get; set; }
        public DbSet<OrderNotificationDto> OrderNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<VehiclesDto>(VehiclesMap.Configure);
            modelBuilder.Entity<DelivererDto>(DeliveryDriverMap.Configure);
            modelBuilder.Entity<RentDto>(RentMap.Configure);
            modelBuilder.Entity<OrderDto>(OrderMap.Configure);
            modelBuilder.Entity<OrderNotificationDto>(OrderNotificationMap.Configure);

            base.OnModelCreating(modelBuilder);
        }
    }
}
