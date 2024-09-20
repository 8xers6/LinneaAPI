using LinneaAPI.Models;

namespace LinneaAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string VehicleId { get; set; }
        public List<Location> Locations { get; set; }
    }
}
