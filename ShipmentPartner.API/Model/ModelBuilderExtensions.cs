using Microsoft.EntityFrameworkCore;
using CargoShipment.Currier.Models;

namespace CargoShipment.Currier.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Delivery>().HasData(
                new Delivery { Id = 1, RegionAddress = "Example address", SKU = "AWMGSJ" }    
               );

        } 
    }
}
