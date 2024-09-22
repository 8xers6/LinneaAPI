namespace LinneaAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string VehicleId { get; set; }
        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Longitude { get; set; }
    }
}
