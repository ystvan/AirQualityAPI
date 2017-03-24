using AirQualityAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirQualityAPI.Contexts
{
    public class OzonesContext : DbContext
    {
        public OzonesContext(DbContextOptions<OzonesContext> options)
            : base(options) { }

        public OzonesContext()
        {
        }
        public DbSet<Ozone> Ozone { get; set; }
    }
}
