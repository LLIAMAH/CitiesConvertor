using Cities.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cities.DB
{
    public class AppDbCtx : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityType> CityTypes { get; set; }

        public AppDbCtx(DbContextOptions<AppDbCtx> options) : base(options) { }
    }
}