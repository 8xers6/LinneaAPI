using LinneaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LinneaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
