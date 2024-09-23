using LinneaAPI.Data;
using LinneaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VehicleControllerAPI : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VehicleController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Location>>> GetVehicleLocations(string id)
    {
        var locations = await _context.Locations
            .Where(l => l.VehicleId == id)
            .ToListAsync();

        if (locations == null)
        {
            return NotFound();
        }

        return locations;
    }

    [HttpPost("location")]
    public async Task<IActionResult> PostLocation([FromBody] string locationData)
    {
        var data = locationData.Split(',');
        if (data.Length != 3)
        {
            return BadRequest("Invalid data format.");
        }

        var location = new Location
        {
            VehicleId = data[0],
            Latitude = float.Parse(data[1]),
            Longitude = float.Parse(data[2])
        };

        _context.Locations.Add(location);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
