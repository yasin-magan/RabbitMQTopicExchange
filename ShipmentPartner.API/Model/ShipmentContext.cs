using Microsoft.EntityFrameworkCore;

namespace CargoShipment.Currier.Models
{
    public class ShipmentContext : DbContext
    {
        public ShipmentContext(DbContextOptions<ShipmentContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Delivery>();
            modelBuilder.Seed();

        }
        public DbSet<Delivery> Deliverys { get; set; }
    }
}
