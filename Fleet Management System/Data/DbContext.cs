using Fleet_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Fleet_Management_System.Data
{
    public class FleetManagementContext : DbContext
    {
        public FleetManagementContext(DbContextOptions<FleetManagementContext> options) : base(options) { }

        public DbSet<VehicleLocation> VehicleLocations { get; set; }
        public DbSet<VehicleLocationResults> VehicleLocationResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<VehicleLocationResults>().HasNoKey();
        }

    }
}
