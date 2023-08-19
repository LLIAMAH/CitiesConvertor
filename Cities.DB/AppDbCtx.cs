using Cities.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cities.DB
{
    public class AppDbCtx : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Test1> Tests1 { get; set; }
        public DbSet<TestMany> TestsManies { get; set; }

        public AppDbCtx(DbContextOptions<AppDbCtx> options) : base(options) { }
    }
}