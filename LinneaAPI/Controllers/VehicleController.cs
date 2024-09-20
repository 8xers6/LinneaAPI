using LinneaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinneaAPI.Data;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehicleController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Location>>> GetVehicleLocations(string id)
    {
        try
        {
            var vehicle = await _context.Vehicles
                                        .AsNoTracking()
                                        .Include(v => v.Locations)
                                        .FirstOrDefaultAsync(v => v.VehicleId == id);

            if (vehicle == null)
            {
                return NotFound();
            }


            return Ok(vehicle.Locations);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error");
        }
    }



    [HttpPost("location")]
    public async Task<IActionResult> PostLocation([FromBody] Location data)
    {
        if (data == null)
        {
            return BadRequest("Data cannot be null.");
        }

        var location = new Location
        {
            VehicleId = data.VehicleId,
            Latitude = data.Latitude,
            Longitude = data.Longitude,
            Timestamp = DateTime.UtcNow
        };

        try
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex) { 

            return StatusCode(500, "Internal server error");
        }

        return NoContent();
    }
}
