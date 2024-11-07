
using Fleet_Management_System.Data;
using Fleet_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleet_Management_System.Repository
{
    public class VehicleRepository
    {
        private readonly  FleetManagementContext _context;

        public VehicleRepository(FleetManagementContext context)
        {
            _context = context;
        }


        public async Task<List<VehicleLocationResults>> GetLatestVehicleLocationsAsync()
        {
            return await _context.VehicleLocationResults
                .FromSqlRaw("EXEC sp_GetLatestVehicleLocations")
                .ToListAsync();
        }

         
        public async Task SaveVehicleLocationAsync(VehicleLocation location)
        {
            _context.Add(location);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VehicleLocationResults>> GetAllVehicleLocation()
        {
            return await _context.VehicleLocations
                .OrderBy(v => v.Timestamp)  
                .Select(v => new VehicleLocationResults
                {
                    Id = v.Id,
                    VehicleId = v.VehicleId,
                    Latitude = v.Latitude,
                    Longitude = v.Longitude,
                    Timestamp = v.Timestamp
                })
                .ToListAsync();
        }
    }
}
