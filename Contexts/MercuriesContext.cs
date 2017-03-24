using AirQualityAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirQualityAPI.Contexts
{
    public class MercuriesContext : DbContext
    {
        public MercuriesContext(DbContextOptions<MercuriesContext> options)
            : base(options) { }

        public MercuriesContext()
        {
        }
        public DbSet<Mercury> Mercury { get; set; }
    }
}
