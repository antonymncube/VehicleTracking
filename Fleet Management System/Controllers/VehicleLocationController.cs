using Fleet_Management_System.Models;
using Fleet_Management_System.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fleet_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleLocationController : ControllerBase
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleLocationController(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // Endpoint to save vehicle location
        [HttpPost("location")]
        public async Task<IActionResult> PostLocation([FromBody] VehicleLocation location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _vehicleRepository.SaveVehicleLocationAsync(location);
            return Ok("Vehicle location saved successfully.");
        }

        // Endpoint to get the latest locations of all vehicles
        [HttpGet("locations")]
        public async Task<ActionResult<List<VehicleLocationResults>>> GetLatestLocations()
        {
            var locations = await _vehicleRepository.GetLatestVehicleLocationsAsync();
            return Ok(locations);
        }

        [HttpGet("AllVehiclelocations")]
        public async Task<ActionResult<List<VehicleLocationResults>>> GetallVehiclelist()
        {
            var locations = await _vehicleRepository.GetAllVehicleLocation();
            return Ok(locations);
        }
    }
}
